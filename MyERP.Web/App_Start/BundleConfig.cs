using System.Web.Optimization;

namespace MyERP.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Resources/js").Include(
                        "~/Resources/main.js",
                        "~/Resources/perfect-scrollbar.min.js"));

            bundles.Add(new StyleBundle("~/Resources/css").Include(
                     "~/Resources/main.css"));
#if DEBUG
            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862

            BundleTable.EnableOptimizations = false;
#endif
        }
    }
}