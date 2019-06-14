// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace sistema.Controllers
{
    public class HomeController : Controller
    {

        Funciones funcion = new Funciones();

        string cookie_name = ConfigurationManager.AppSettings["cookie_name"].ToString();

        public ActionResult Index()
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    return RedirectToAction("Index", "Administracion");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
    }
}
