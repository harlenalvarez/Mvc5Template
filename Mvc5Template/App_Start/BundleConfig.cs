using System.Web;
using System.Web.Optimization;

namespace Mvc5Template
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Css/bootstrap.css",
                      "~/Content/Css/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/highlight").Include(
                        "~/Scripts/highlight.pack.js"));

            bundles.Add(new StyleBundle("~/Content/highlight").Include(
                      "~/Content/Css/vs.css"));

            bundles.Add(new ScriptBundle("~/bundles/typeahead").Include(
                      "~/Scripts/typeahead.*",
                      "~/Scripts/bloodhound.*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                        "~/Scripts/App/MainScripts.js",
                        "~/Scripts/App/CustomValidators.js"));
            
        }
    }
}
