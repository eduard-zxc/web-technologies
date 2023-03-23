using System.Web.Optimization;

namespace eUseControl.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Home style
            bundles.Add(new StyleBundle("~/bundles/main/css").Include(
                      "~/assets/css/style.css", new CssRewriteUrlTransform()));

            // Pe-icon-7-stroke
            bundles.Add(new StyleBundle("~/bundles/peicon7stroke/css").Include(
                      "~/assets/css/pe-icon-7-stroke.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/materialdesignicons/css").Include(
                     "~/assets/css/materialdesignicons.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/bootstrap.min/css").Include(
                     "~/assets/css/bootstrap.min.css", new CssRewriteUrlTransform()));

            // SCSS
            bundles.Add(new StyleBundle("~/bundles/style/scss").Include(
                "~/assets/scss/style.scss", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/_variable/scss").Include(
                "~/assets/scss/_variable.scss", new CssRewriteUrlTransform()));

            // Bootstrap style
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                      "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));

            // Font Awesome icons style
            bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include(
                      "~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));

            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                      "~/Scripts/bootstrap.min.js"));

            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                      "~/Scripts/jquery-3.6.3.min.js"));

            // Unobtrusive           
            bundles.Add(new ScriptBundle("~/bundles/unobtrusive/js").Include(
                      "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            // Pace
            bundles.Add(new ScriptBundle("~/bundles/pace/js").Include(
                      "~/Scripts/pace.min.js"));

            // Assets 
            bundles.Add(new ScriptBundle("~/bundles/app/js").Include(
                      "~/assets/js/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap.bundle.min/js").Include(
                "~/assets/js/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/counter.init/js").Include(
                "~/assets/js/counter.init.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.easing.min/js").Include(
                "~/assets/js/jquery.easing.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.min/js").Include(
                "~/assets/js/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scrollspy.min/js").Include(
                "~/assets/js/scrollspy.min.js"));

            // jQuery Validation
            bundles.Add(new ScriptBundle("~/bundles/validation/js").Include(
                      "~/Scripts/jquery.validate.min.js"));
<<<<<<< HEAD
=======

>>>>>>> 671bf15a2cc30ed8078d91f3f87d0efbbe83fc7f
            // PHP
            bundles.Add(new ScriptBundle("~/bundles/contact/php").Include(
                "~/assets/php/contact.php"));
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 671bf15a2cc30ed8078d91f3f87d0efbbe83fc7f
