using System.Web;
using System.Web.Optimization;

namespace sistema
{
    public class BundleConfig
    {
        // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap/css/bootstrap.css",
            "~/Content/css/style.css",
            "~/Content/css/bootstrapValidator.css",
            "~/Content/dist/sweetalert.css"));

            bundles.Add(new ScriptBundle("~/Content/Scripts").Include(
                        "~/Content/js/jquery-3.2.1.js",
                        "~/Content/bootstrap/js/bootstrap.js",
                        "~/Content/dist/sweetalert-dev.js",
                        "~/Content/js/bootstrapValidator.js",
                        "~/Content/js/app.js"));
        }
    }
}