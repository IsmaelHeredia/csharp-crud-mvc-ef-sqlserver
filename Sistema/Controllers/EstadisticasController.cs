// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;

namespace sistema.Controllers
{
    public class EstadisticasController : Controller
    {

        Funciones funcion = new Funciones();

        string cookie_name = ConfigurationManager.AppSettings["cookie_name"].ToString();

        //
        // GET: /Estadisticas/

        public ActionResult Index()
        {
            return View("Reporte");
        }

        public ActionResult Visualizar()
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    CrystalDecisions.CrystalReports.Engine.ReportDocument reporte = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    reporte.Load(Server.MapPath("~/Reports/Reporte.rpt"));
                    reporte.SetDatabaseLogon("admin", "123456", "SINDECIDIR-PC", "sistemaV2");
                    reporte.Refresh();
                    try
                    {
                        Stream stream = reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        stream.Seek(0, SeekOrigin.Begin);
                        return new FileStreamResult(stream, "application/pdf");
                    }
                    catch
                    {
                        throw;
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

        public ActionResult Descargar()
        {
            if (Request.Cookies[cookie_name] != null)
            {
                if (funcion.valid_cookie(Request.Cookies[cookie_name].Value))
                {
                    CrystalDecisions.CrystalReports.Engine.ReportDocument reporte = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    reporte.Load(Server.MapPath("~/Reports/Reporte.rpt"));
                    reporte.SetDatabaseLogon("admin", "123456", "SINDECIDIR-PC", "sistemaV2");
                    reporte.Refresh();
                    try
                    {
                        Stream stream = reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        stream.Seek(0, SeekOrigin.Begin);
                        return File(stream, "application/pdf", "Sistema_Reporte.pdf");
                    }
                    catch
                    {
                        throw;
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
