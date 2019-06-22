using System.Web.Optimization;

namespace ASPNET_MVC.App_Start
{
    public class BundleConfig
    {
        // Nuget Optimization ekle
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Bundle debug modda çalışmaz
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-3.0.0.js",
                "~/Scripts/jquery-2.2.4.js",
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/jquery.easing.1.3.js",
                "~/Scripts/custom/sb-admin.min.js",
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap4.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/bootbox.min.js",
                "~/Scripts/jquery.signalR-2.2.2.js",
                "~/Scripts/custom/addtohomescreen.js",
                "~/Scripts/custom/JavaScript.js"
               ));
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/css/sb-admin.css",
                "~/Content/css/site.css",
                "~/Content/DataTables/css/dataTables.bootstrap4.min.css",
                "~/Content/css/addtohomescreen.css"
                ));
        }
    }
}