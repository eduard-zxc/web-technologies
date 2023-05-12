using System.Web.Optimization;

namespace eUseControl.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
             //CSS
             bundles.Add(new StyleBundle("~/bundles/main/css").Include(
                  "~/assets/css/main.css", new CssRewriteUrlTransform()));

             bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                  "~/assets/css/bootstrap.min.css", new CssRewriteUrlTransform()));

             bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include(
                  "~/assets/css/font-awesome.min.css", new CssRewriteUrlTransform()));

             bundles.Add(new StyleBundle("~/bundles/aos/css").Include(
                  "~/assets/css/aos.css", new CssRewriteUrlTransform()));

             bundles.Add(new StyleBundle("~/bundles/validation/css").Include(
                  "~/assets/css/validation.css", new CssRewriteUrlTransform()));



               //JS
               bundles.Add(new ScriptBundle("~/bundles/aos/js").Include(
                  "~/assets/js/aos.js"));

             bundles.Add(new ScriptBundle("~/bundles/bootstrap.min/js").Include(
                  "~/assets/js/bootstrap.min.js"));

             bundles.Add(new ScriptBundle("~/bundles/custom/js").Include(
                  "~/assets/js/custom.js"));

             bundles.Add(new ScriptBundle("~/bundles/jquery.min/js").Include(
                  "~/assets/js/jquery.min.js"));

             bundles.Add(new ScriptBundle("~/bundles/smoothscroll/js").Include(
                  "~/assets/js/smoothscroll.js"));

             bundles.Add(new ScriptBundle("~/bundles/up/js").Include(
                  "~/assets/js/up.js"));

             // jQuery Validation
             bundles.Add(new ScriptBundle("~/bundles/validation/js").Include(
                  "~/Scripts/jquery.validate.min.js"));

          }
     }
}