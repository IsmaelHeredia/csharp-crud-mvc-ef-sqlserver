// Written By Ismael Heredia in the year 2017

using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;

namespace sistema.Controllers
{
    public class AdministracionController : Controller
    {

        private UsuarioBL usuarioBL = new UsuarioBL();

        Funciones funcion = new Funciones();

        string cookie_name = ConfigurationManager.AppSettings["cookie_name"].ToString();

        //
        // GET: /Administracion/

        public ActionResult Index()
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    var contenido = Request.Cookies[cookie_name].Value;

                    string usuario = funcion.get_username_in_cookie(contenido);
                    string tipo_usuario = usuarioBL.get_user_type(usuario);

                    if (TempData["mensaje"] != null)
                    {
                        ViewBag.mensaje = TempData["mensaje"].ToString();
                    }

                    ViewBag.usuario = usuario;
                    ViewBag.tipo_usuario = tipo_usuario;

                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }  
}
