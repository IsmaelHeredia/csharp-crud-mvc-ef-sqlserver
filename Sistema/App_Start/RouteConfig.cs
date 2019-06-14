using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace sistema
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Home

            routes.MapRoute(
                name: "Raiz",
                url: "",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] {"GET"}) }
            );

            // Login

            routes.MapRoute(
                name: "Login",
                url: "Login/IngresoUsuario",
                defaults: new { controller = "Login", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "Salir",
                url: "Login/LogOut",
                defaults: new { controller = "Login", action = "LogOut" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "Ingreso",
                url: "Login/IngresoUsuario",
                defaults: new { controller = "Login", action = "IngresoUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            // Admin

            routes.MapRoute(
                name: "Admin",
                url: "Administracion",
                defaults: new { controller = "Administracion", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            // Reporte

            routes.MapRoute(
                name: "Reporte",
                url: "Administracion/Estadisticas",
                defaults: new { controller = "Estadisticas", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "VisualizarReporte",
                url: "Administracion/Estadisticas/Visualizar",
                defaults: new { controller = "Estadisticas", action = "Visualizar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "DescargarReporte",
                url: "Administracion/Estadisticas/Descargar",
                defaults: new { controller = "Estadisticas", action = "Descargar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            // Cambiar Usuario

            routes.MapRoute(
                name: "CambiarUsuarioGET",
                url: "Administracion/Cuenta/CambiarUsuario",
                defaults: new { controller = "Cuenta", action = "CambiarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "CambiarUsuarioPOST",
                url: "Administracion/Cuenta/CambiarUsuario",
                defaults: new { controller = "Cuenta", action = "CambiarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            // Cambiar Clave

            routes.MapRoute(
                name: "CambiarClaveGET",
                url: "Administracion/Cuenta/CambiarClave",
                defaults: new { controller = "Cuenta", action = "CambiarClave" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "CambiarClavePOST",
                url: "Administracion/Cuenta/CambiarClave",
                defaults: new { controller = "Cuenta", action = "CambiarClave" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            // Productos

            routes.MapRoute(
                name: "ListarProductosGET",
                url: "Administracion/Productos/Listar",
                defaults: new { controller = "Productos", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "ListarProductosPOST",
                url: "Administracion/Productos/Listar",
                defaults: new { controller = "Productos", action = "Listar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "AgregarProductoGET",
                url: "Administracion/Productos/Agregar",
                defaults: new { controller = "Productos", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "AgregarProductoPOST",
                url: "Administracion/Productos/Agregar",
                defaults: new { controller = "Productos", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "EditarProductoGET",
                url: "Administracion/Productos/Editar/{id}",
                defaults: new { controller = "Productos", action = "Editar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "EditarProductoPOST",
                url: "Administracion/Productos/Editar",
                defaults: new { controller = "Productos", action = "GrabarEditar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "BorrarProductoGET",
                url: "Administracion/Productos/Borrar/{id}",
                defaults: new { controller = "Productos", action = "ConfirmarBorrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "BorrarProductoPOST",
                url: "Administracion/Productos/Borrar",
                defaults: new { controller = "Productos", action = "Borrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            // Proveedores

            routes.MapRoute(
                name: "ListarProveedoresGET",
                url: "Administracion/Proveedores/Listar",
                defaults: new { controller = "Proveedores", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "ListarProveedoresPOST",
                url: "Administracion/Proveedores/Listar",
                defaults: new { controller = "Proveedores", action = "Listar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "AgregarProveedorGET",
                url: "Administracion/Proveedores/Agregar",
                defaults: new { controller = "Proveedores", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "AgregarProveedorPOST",
                url: "Administracion/Proveedores/Agregar",
                defaults: new { controller = "Proveedores", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "EditarProveedorGET",
                url: "Administracion/Proveedores/Editar/{id}",
                defaults: new { controller = "Proveedores", action = "Editar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "EditarProveedorPOST",
                url: "Administracion/Proveedores/Editar",
                defaults: new { controller = "Proveedores", action = "GrabarEditar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "BorrarProveedorGET",
                url: "Administracion/Proveedores/Borrar/{id}",
                defaults: new { controller = "Proveedores", action = "ConfirmarBorrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "BorrarProveedorPOST",
                url: "Administracion/Proveedores/Borrar",
                defaults: new { controller = "Proveedores", action = "Borrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            // Usuarios

            routes.MapRoute(
                name: "ListarUsuariosGET",
                url: "Administracion/Usuarios/Listar",
                defaults: new { controller = "Usuarios", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "ListarUsuariosPOST",
                url: "Administracion/Usuarios/Listar",
                defaults: new { controller = "Usuarios", action = "Listar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "AgregarUsuarioGET",
                url: "Administracion/Usuarios/Agregar",
                defaults: new { controller = "Usuarios", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "AgregarUsuarioPOST",
                url: "Administracion/Usuarios/Agregar",
                defaults: new { controller = "Usuarios", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "EditarUsuarioGET",
                url: "Administracion/Usuarios/Editar/{id}",
                defaults: new { controller = "Usuarios", action = "Editar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "EditarUsuarioPOST",
                url: "Administracion/Usuarios/Editar",
                defaults: new { controller = "Usuarios", action = "GrabarEditar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "BorrarUsuarioGET",
                url: "Administracion/Usuarios/Borrar/{id}",
                defaults: new { controller = "Usuarios", action = "ConfirmarBorrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "BorrarUsuarioPOST",
                url: "Administracion/Usuarios/Borrar",
                defaults: new { controller = "Usuarios", action = "Borrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

        }
    }
}