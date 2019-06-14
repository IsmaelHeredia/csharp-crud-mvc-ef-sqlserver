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
    public class UsuariosController : Controller
    {

        private UsuarioBL usuarioBL = new UsuarioBL();
        private TipoUsuarioBL tiposBL = new TipoUsuarioBL();

        Funciones funcion = new Funciones();

        string cookie_name = ConfigurationManager.AppSettings["cookie_name"].ToString();

        public ActionResult Index()
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    if (funcion.valid_cookie_admin(Request.Cookies[cookie_name].Value))
                    {
                        ViewBag.usuario = funcion.get_username_in_cookie(Request.Cookies[cookie_name].Value);
                        if (TempData["mensaje"] != null)
                        {
                            ViewBag.mensaje = TempData["mensaje"].ToString();
                        }
                        ViewBag.cantidad_usuarios = usuarioBL.List("").Count();
                        return View("Listar", usuarioBL.List(""));
                    }
                    else
                    {
                        TempData["mensaje"] = funcion.mensaje("Usuarios", "Acceso Denegado", "error");
                        return RedirectToAction("Index", "Administracion");
                    }
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

        [ActionName("Listar"), HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Listar(Entities.Buscador model)
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    if (funcion.valid_cookie_admin(Request.Cookies[cookie_name].Value))
                    {
                        ViewBag.usuario = funcion.get_username_in_cookie(Request.Cookies[cookie_name].Value);
                        ViewBag.cantidad_usuarios = usuarioBL.List("").Count();
                        return View(usuarioBL.List(model.nombre_buscar));
                    }
                    else
                    {
                        TempData["mensaje"] = funcion.mensaje("Usuarios", "Acceso Denegado", "error");
                        return RedirectToAction("Index", "Administracion");
                    }
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

        public ActionResult Agregar()
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    if (funcion.valid_cookie_admin(Request.Cookies[cookie_name].Value))
                    {
                        ViewBag.usuario = funcion.get_username_in_cookie(Request.Cookies[cookie_name].Value);
                        if (TempData["mensaje"] != null)
                        {
                            ViewBag.mensaje = TempData["mensaje"].ToString();
                        }
                        ViewBag.tipos = tiposBL.List("");
                        return View("Agregar");
                    }
                    else
                    {
                        TempData["mensaje"] = funcion.mensaje("Usuarios", "Acceso Denegado", "error");
                        return RedirectToAction("Index", "Administracion");
                    }
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

        [ActionName("Agregar"), HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Entities.Usuario model)
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    if (funcion.valid_cookie_admin(Request.Cookies[cookie_name].Value))
                    {
                        string texto = "";
                        string tipo = "";

                        if (ModelState.IsValid)
                        {
                            Usuario usuario = new Usuario();
                            usuario.nombre = model.nombre;
                            usuario.clave = funcion.md5_encode(model.clave);
                            usuario.id_tipo = model.id_tipo;
                            usuario.fecha_registro = funcion.fecha_del_dia();

                            if (usuarioBL.check_exists_usuario_add(usuario.nombre))
                            {
                                texto = "El usuario " + usuario.nombre + " ya existe";
                                tipo = "warning";
                            }
                            else
                            {
                                if (usuarioBL.Add(usuario))
                                {
                                    texto = "El usuario ha sido registrado exitosamente";
                                    tipo = "success";
                                }
                                else
                                {
                                    texto = "Ha ocurrido un error en la base de funcion";
                                    tipo = "error";

                                }
                            }

                        }
                        else
                        {
                            texto = "Los datos ingresados en el formulario son inválidos";
                            tipo = "warning";
                        }

                        TempData["mensaje"] = funcion.mensaje("Usuarios", texto, tipo);

                        if (tipo == "success")
                        {
                            return RedirectToAction("Index", "Usuarios");
                        }
                        else
                        {
                            return RedirectToAction("Agregar", "Usuarios");
                        }
                    }
                    else
                    {
                        TempData["mensaje"] = funcion.mensaje("Usuarios", "Acceso Denegado", "error");
                        return RedirectToAction("Index", "Administracion");
                    }
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

        public ActionResult Editar(int id)
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    if (funcion.valid_cookie_admin(Request.Cookies[cookie_name].Value))
                    {
                        ViewBag.usuario = funcion.get_username_in_cookie(Request.Cookies[cookie_name].Value);
                        if (TempData["mensaje"] != null)
                        {
                            ViewBag.mensaje = TempData["mensaje"].ToString();
                        }
                        ViewBag.tipos = tiposBL.List("");
                        Usuario usuario = usuarioBL.Get(id);
                        if (usuario == null)
                        {
                            return HttpNotFound();
                        }
                        return View(usuario);
                    }
                    else
                    {
                        TempData["mensaje"] = funcion.mensaje("Usuarios", "Acceso Denegado", "error");
                        return RedirectToAction("Index", "Administracion");
                    }
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

        [ActionName("GrabarEditar"), HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GrabarEditar(Entities.Usuario model)
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    if (funcion.valid_cookie_admin(Request.Cookies[cookie_name].Value))
                    {
                        string texto = "";
                        string tipo = "";

                        if (funcion.valid_number(model.id_tipo.ToString()))
                        {
                            Usuario usuario = new Usuario();
                            usuario.id = model.id;
                            usuario.id_tipo = model.id_tipo;

                            if (usuarioBL.Update(usuario))
                            {
                                texto = "El usuario ha sido editado exitosamente";
                                tipo = "success";
                            }
                            else
                            {
                                texto = "Ha ocurrido un error en la base de funcion";
                                tipo = "error";
                            }

                        }
                        else
                        {
                            texto = "Los datos ingresados en el formulario son inválidos";
                            tipo = "warning";
                        }

                        TempData["mensaje"] = funcion.mensaje("Usuarios", texto, tipo);

                        if (tipo == "success")
                        {
                            return RedirectToAction("Index", "Usuarios");
                        }
                        else
                        {
                            return RedirectToAction("Editar", "Usuarios", new { id = model.id });
                        }
                    }
                    else
                    {
                        TempData["mensaje"] = funcion.mensaje("Usuarios", "Acceso Denegado", "error");
                        return RedirectToAction("Index", "Administracion");
                    }
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

        public ActionResult ConfirmarBorrar(int id)
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    if (funcion.valid_cookie_admin(Request.Cookies[cookie_name].Value))
                    {
                        ViewBag.usuario = funcion.get_username_in_cookie(Request.Cookies[cookie_name].Value);
                        Usuario usuario = usuarioBL.Get(id);
                        if (usuario == null)
                        {
                            return HttpNotFound();
                        }
                        return View("Borrar", usuario);
                    }
                    else
                    {
                        TempData["mensaje"] = funcion.mensaje("Usuarios", "Acceso Denegado", "error");
                        return RedirectToAction("Index", "Administracion");
                    }
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

        [ActionName("Borrar"), HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Borrar()
        {
            int id = Convert.ToInt32(Request["id"]);
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    if (funcion.valid_cookie_admin(Request.Cookies[cookie_name].Value))
                    {
                        string texto = "";
                        string tipo = "";

                        if (funcion.valid_number(id.ToString()))
                        {
                            if (usuarioBL.Delete(id))
                            {
                                texto = "El usuario ha sido borrado exitosamente";
                                tipo = "success";
                            }
                            else
                            {
                                texto = "Ha ocurrido un error en la base de funcion";
                                tipo = "error";
                            }
                        }
                        else
                        {
                            texto = "ID Inválido";
                            tipo = "warning";
                        }

                        TempData["mensaje"] = funcion.mensaje("Usuarios", texto, tipo);
                        return RedirectToAction("Index", "Usuarios");
                    }
                    else
                    {
                        TempData["mensaje"] = funcion.mensaje("Usuarios", "Acceso Denegado", "error");
                        return RedirectToAction("Index", "Administracion");
                    }
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
