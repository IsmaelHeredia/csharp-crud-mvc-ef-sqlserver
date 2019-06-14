// Written By Ismael Heredia in the year 2017

using Entities;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace sistema.Controllers
{
    public class LoginController : Controller
    {

        Funciones funcion = new Funciones();
        UsuarioBL usuarioBL = new UsuarioBL();

        string cookie_name = ConfigurationManager.AppSettings["cookie_name"].ToString();

        //
        // GET: /Login/

        public ActionResult Index()
        {
            if (Request.Cookies[cookie_name] == null)
            {
                if (TempData["mensaje"] != null)
                {
                    ViewBag.mensaje = TempData["mensaje"].ToString();
                }
                return View("Ingreso");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            if (Request.Cookies[cookie_name] != null)
            {
                var contenido = new HttpCookie(cookie_name);
                contenido.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(contenido);
                TempData["mensaje"] = funcion.mensaje("Cerrar sesión", "Las cookies han sido borradas", "success");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [ActionName("IngresoUsuario"), HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IngresoUsuario(Entities.Login model)
        {
            string texto = "";
            string tipo = "";
            
            if(ModelState.IsValid) {
                
                string username_login = model.usuario;
                string password_encoded = funcion.md5_encode(model.clave);
                if(usuarioBL.check_login(username_login,password_encoded)) {
                    var userCookie = new HttpCookie(cookie_name,username_login+"-"+password_encoded);
                    userCookie.Expires.AddDays(365);
                    HttpContext.Response.Cookies.Add(userCookie);
                    string tipo_usuario = usuarioBL.get_user_type(username_login);
                    texto = "Bienvenido a la sección de administración " + tipo_usuario + " " + username_login;
                    tipo = "success";
                } else {
                    texto = "Datos incorrectos";
                    tipo = "warning";
                }
  
            } else {
                texto = "Faltan datos";
                tipo = "warning";
            }

            TempData["mensaje"] = funcion.mensaje("Iniciar sesión", texto, tipo);

            if (tipo == "success")
            {
                return RedirectToAction("Index", "Administracion");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


    }
}
