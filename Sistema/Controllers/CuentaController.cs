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
    public class CuentaController : Controller
    {

        private UsuarioBL usuarioBL = new UsuarioBL();
        Funciones funcion = new Funciones();

        string cookie_name = ConfigurationManager.AppSettings["cookie_name"].ToString();

        public ActionResult CambiarUsuario()
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    ViewBag.usuario = funcion.get_username_in_cookie(Request.Cookies[cookie_name].Value);
                    if (TempData["mensaje"] != null)
                    {
                        ViewBag.mensaje = TempData["mensaje"].ToString();
                    }
                    var contenido = Request.Cookies[cookie_name].Value;
                    string usuario = funcion.get_username_in_cookie(contenido);
                    CambiarUsuario model = new CambiarUsuario { usuario = usuario };
                    return View("CambiarUsuario",model);
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        [ActionName("CambiarUsuario"), HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CambiarUsuario(Entities.CambiarUsuario model)
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    string texto = "";
                    string tipo = "";

                    if (ModelState.IsValid)
                    {
                        string usuario = model.usuario;
                        string clave = model.clave;
                        string nuevo_usuario = model.nuevo_usuario;

                        int id = usuarioBL.get_id_by_user(usuario);
                        string clave_encoded = funcion.md5_encode(clave);

                        if (usuarioBL.check_login(usuario, clave_encoded))
                        {
                            if (usuarioBL.check_exists_usuario_add(nuevo_usuario))
                            {
                                texto = "El usuario " + nuevo_usuario + " ya existe";
                                tipo = "warning";
                            }
                            else
                            {
                                if (usuarioBL.change_username(id, nuevo_usuario))
                                {
                                    texto = "El usuario ha sido cambiado exitosamente, reinicie la aplicación";
                                    tipo = "success";
                                }
                                else
                                {
                                    texto = "Ha ocurrido un error en la base de datos";
                                    tipo = "error";
                                }
                            }
                        }
                        else
                        {
                            texto = "Los datos del usuario son inválidos";
                            tipo = "warning";
                        }

                    }
                    else
                    {
                        texto = "Los datos son inválidos";
                        tipo = "warning";
                    }

                    if (tipo == "success")
                    {
                        var cookie = new HttpCookie(cookie_name);
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(cookie);

                        TempData["mensaje"] = funcion.mensaje("Cambiar Usuario", texto, tipo);
                        return RedirectToAction("Index", "Login");

                    }
                    else
                    {
                        TempData["mensaje"] = funcion.mensaje("Cambiar Usuario", texto, tipo);
                        return RedirectToAction("CambiarUsuario", "Cuenta");
                    }

                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        public ActionResult CambiarClave()
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    ViewBag.usuario = funcion.get_username_in_cookie(Request.Cookies[cookie_name].Value);
                    if (TempData["mensaje"] != null)
                    {
                        ViewBag.mensaje = TempData["mensaje"].ToString();
                    }
                    var contenido = Request.Cookies[cookie_name].Value;
                    string usuario = funcion.get_username_in_cookie(contenido);
                    CambiarClave model = new CambiarClave { usuario = usuario };
                    return View("CambiarClave",model);
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        [ActionName("CambiarClave"), HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CambiarClave(Entities.CambiarClave model)
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    string texto = "";
                    string tipo = "";

                    if (ModelState.IsValid)
                    {
                        string usuario = model.usuario;
                        string clave = model.clave;
                        string nueva_clave = model.nueva_clave;

                        int id = usuarioBL.get_id_by_user(usuario);
                        string clave_encoded = funcion.md5_encode(clave);
                        string nueva_clave_encoded = funcion.md5_encode(nueva_clave);

                        if (usuarioBL.check_login(usuario, clave_encoded))
                        {
                            if (usuarioBL.change_password(id, nueva_clave_encoded))
                            {
                                texto = "La clave ha sido cambiada exitosamente, reinicie la aplicación";
                                tipo = "success";
                            }
                            else
                            {
                                texto = "Ha ocurrido un error en la base de datos";
                                tipo = "error";
                            }
                        }
                        else
                        {
                            texto = "Los datos del usuario son inválidos";
                            tipo = "warning";
                        }

                    }
                    else
                    {
                        texto = "Los datos son inválidos";
                        tipo = "warning";
                    }

                    if (tipo == "success")
                    {
                        var cookie = new HttpCookie(cookie_name);
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(cookie);

                        TempData["mensaje"] = funcion.mensaje("Cambiar Clave", texto, tipo);
                        return RedirectToAction("Index", "Login");

                    }
                    else
                    {
                        TempData["mensaje"] = funcion.mensaje("Cambiar Clave", texto, tipo);
                        return RedirectToAction("CambiarClave", "Cuenta");
                    }

                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

    }
}
