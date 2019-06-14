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
    public class ProveedoresController : Controller
    {

        private ProveedorBL proveedorBL = new ProveedorBL();

        Funciones funcion = new Funciones();

        string cookie_name = ConfigurationManager.AppSettings["cookie_name"].ToString();

        public ActionResult Index()
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
                    ViewBag.cantidad_proveedores = proveedorBL.List("").Count();
                    return View("Listar", proveedorBL.List(""));
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
                    ViewBag.usuario = funcion.get_username_in_cookie(Request.Cookies[cookie_name].Value);
                    ViewBag.cantidad_proveedores = proveedorBL.List("").Count();
                    return View(proveedorBL.List(model.nombre_buscar));
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
                    ViewBag.usuario = funcion.get_username_in_cookie(Request.Cookies[cookie_name].Value);
                    if (TempData["mensaje"] != null)
                    {
                        ViewBag.mensaje = TempData["mensaje"].ToString();
                    }
                    return View("Agregar");
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
        public ActionResult Agregar(Entities.Proveedor model)
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {

                    string texto = "";
                    string tipo = "";

                    if (ModelState.IsValid)
                    {

                        Proveedor proveedor = new Proveedor();
                        proveedor.nombre = model.nombre;
                        proveedor.direccion = model.direccion;
                        proveedor.telefono = model.telefono;
                        proveedor.fecha_registro = funcion.fecha_del_dia();

                        if (proveedorBL.check_exists_proveedor_add(proveedor.nombre))
                        {
                            texto = "El proveedor " + proveedor.nombre + " ya existe";
                            tipo = "warning";
                        }
                        else
                        {
                            if (proveedorBL.Add(proveedor))
                            {
                                texto = "El proveedor ha sido registrado exitosamente";
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

                    TempData["mensaje"] = funcion.mensaje("Proveedores", texto, tipo);

                    if (tipo == "success")
                    {
                        return RedirectToAction("Index", "Proveedores");
                    }
                    else
                    {
                        return RedirectToAction("Agregar", "Proveedores");
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
                    ViewBag.usuario = funcion.get_username_in_cookie(Request.Cookies[cookie_name].Value);
                    if (TempData["mensaje"] != null)
                    {
                        ViewBag.mensaje = TempData["mensaje"].ToString();
                    }
                    Proveedor proveedor = proveedorBL.Get(id);
                    if (proveedor == null)
                    {
                        return HttpNotFound();
                    }
                    return View(proveedor);
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
        public ActionResult GrabarEditar(Entities.Proveedor model)
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    string texto = "";
                    string tipo = "";

                    if (ModelState.IsValid)
                    {
                        Proveedor proveedor = new Proveedor();
                        proveedor.id = model.id;
                        proveedor.nombre = model.nombre;
                        proveedor.direccion = model.direccion;
                        proveedor.telefono = model.telefono;

                        if (proveedorBL.check_exists_proveedor_edit(proveedor.id, proveedor.nombre))
                        {
                            texto = "El proveedor " + proveedor.nombre + " ya existe";
                            tipo = "warning";
                        }
                        else
                        {
                            if (proveedorBL.Update(proveedor))
                            {
                                texto = "El proveedor ha sido editado exitosamente";
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

                    TempData["mensaje"] = funcion.mensaje("Proveedores", texto, tipo);

                    if (tipo == "success")
                    {
                        return RedirectToAction("Index", "Proveedores");
                    }
                    else
                    {
                        return RedirectToAction("Editar", "Proveedores", new { id = model.id });
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
                    ViewBag.usuario = funcion.get_username_in_cookie(Request.Cookies[cookie_name].Value);
                    Proveedor proveedor = proveedorBL.Get(id);
                    if (proveedor == null)
                    {
                        return HttpNotFound();
                    }
                    return View("Borrar", proveedor);
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

                    string texto = "";
                    string tipo = "";

                    if (funcion.valid_number(id.ToString()))
                    {
                        if (proveedorBL.Delete(id))
                        {
                            texto = "El proveedor ha sido borrado exitosamente";
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

                    TempData["mensaje"] = funcion.mensaje("Proveedores", texto, tipo);
                    return RedirectToAction("Index", "Proveedores");

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
