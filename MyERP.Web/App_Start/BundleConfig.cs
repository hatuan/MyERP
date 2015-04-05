using System.Web.Optimization;

namespace MyERP.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/datajs").Include(
                      "~/Scripts/datajs-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/myerp").Include(
                      "~/Scripts/myerp.autocomplete.js",
                      "~/Scripts/myerp.toolbar.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                      "~/Scripts/kendo/2015.1.318/kendo.ui.core.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/kendo/cultures").Include(
                      "~/Scripts/kendo/2015.1.318/cultures/kendo.culture.en.min.js",
                      "~/Scripts/kendo/2015.1.318/cultures/kendo.culture.en-US.min.js",
                      "~/Scripts/kendo/2015.1.318/cultures/kendo.culture.vi.min.js",
                      "~/Scripts/kendo/2015.1.318/cultures/kendo.culture.vi-VN.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/themes/base/jquery-ui.css",
                      "~/Content/site.css"));

            //bundles.Add(new StyleBundle("~/Content/datepickercss").Include(
            //          "~/Content/bootstrap-datepicker3.css"));

            //bundles.Add(new StyleBundle("~/Content/jqueryuicss").Include(
            //          "~/Content/themes/jquery-ui.css"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                      "~/Content/kendo/2015.1.318/kendo.common-bootstrap.core.min.css",
                      "~/Content/kendo/2015.1.318/kendo.bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/bundles/knockout").Include(
                      "~/Scripts/knockout-{version}.js"));

#if DEBUG
            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862

            BundleTable.EnableOptimizations = false;
#endif
        }
    }
}