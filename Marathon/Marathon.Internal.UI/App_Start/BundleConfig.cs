using System.Web;
using System.Web.Optimization;

namespace Marathon.Internal.UI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/marathon").Include(
                        "~/Scripts/marathon.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker").Include(
                        "~/Scripts/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/Booking/Shared").Include(
                        "~/Scripts/Booking/Shared.js"));

            bundles.Add(new ScriptBundle("~/bundles/Invoice/Generate").Include(
                        "~/Scripts/Invoice/Generate.js"));

            bundles.Add(new StyleBundle("~/Content/marathon").Include("~/Content/marathon.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-theme.css"));
        }
    }
}