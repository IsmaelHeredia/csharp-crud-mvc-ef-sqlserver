// Written By Ismael Heredia in the year 2017

using BusinessLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace sistema.Controllers
{
    public class ProductosController : Controller
    {
        private ProductoBL productoBL = new ProductoBL();
        private ProveedorBL proveedorBL = new ProveedorBL();
        private UsuarioBL usuarioBL = new UsuarioBL();

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
                    ViewBag.cantidad_productos = productoBL.List("").Count();
                    return View("Listar",productoBL.List(""));
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
                    ViewBag.cantidad_productos = productoBL.List("").Count();
                    return View(productoBL.List(model.nombre_buscar));
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
                    ViewBag.proveedores = proveedorBL.List("");
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
        public ActionResult Agregar(Entities.Producto model)
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {

                    string texto = "";
                    string tipo = "";

                    if (ModelState.IsValid)
                    {

                        Producto producto = new Producto();
                        producto.nombre = model.nombre;
                        producto.descripcion = model.descripcion;
                        producto.precio = model.precio;
                        producto.id_proveedor = model.id_proveedor;
                        producto.fecha_registro = funcion.fecha_del_dia();

                        if (productoBL.check_exists_producto_add(producto.nombre))
                        {
                            texto = "El producto " + producto.nombre + " ya existe";
                            tipo = "warning";
                        }
                        else
                        {
                            if (productoBL.Add(producto))
                            {
                                texto = "El producto ha sido registrado exitosamente";
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

                    TempData["mensaje"] = funcion.mensaje("Productos", texto, tipo);

                    if (tipo == "success")
                    {
                        return RedirectToAction("Index", "Productos");
                    }
                    else
                    {
                        return RedirectToAction("Agregar", "Productos");
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
                    ViewBag.proveedores = proveedorBL.List("");
                    Producto producto = productoBL.Get(id);
                    if (producto == null)
                    {
                        return HttpNotFound();
                    }
                    return View(producto);
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
        public ActionResult GrabarEditar(Entities.Producto model)
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    string texto = "";
                    string tipo = "";

                    if (ModelState.IsValid)
                    {
                        Producto producto = new Producto();
                        producto.id = model.id;
                        producto.nombre = model.nombre;
                        producto.descripcion = model.descripcion;
                        producto.precio = model.precio;
                        producto.id_proveedor = model.id_proveedor;

                        if (productoBL.check_exists_producto_edit(producto.id, producto.nombre))
                        {
                            texto = "El producto " + producto.nombre + " ya existe";
                            tipo = "warning";
                        }
                        else
                        {
                            if (productoBL.Update(producto))
                            {
                                texto = "El producto ha sido editado exitosamente";
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

                    TempData["mensaje"] = funcion.mensaje("Productos", texto, tipo);

                    if (tipo == "success")
                    {
                        return RedirectToAction("Index", "Productos");
                    }
                    else
                    {
                        return RedirectToAction("Editar", "Productos", new { id = model.id});
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
                    Producto producto = productoBL.Get(id);
                    if (producto == null)
                    {
                        return HttpNotFound();
                    }
                    return View("Borrar", producto);
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
                        if (productoBL.Delete(id))
                        {
                            texto = "El producto ha sido borrado exitosamente";
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

                    TempData["mensaje"] = funcion.mensaje("Productos", texto, tipo);
                    return RedirectToAction("Index", "Productos");

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
