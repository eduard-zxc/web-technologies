using System.Web.Optimization;

namespace eUseControl.Web
{
     public static class BundleConfig
     {
          public static void RegisterBundles(BundleCollection bundles)
          {
               //CSS
               bundles.Add(new StyleBundle("~/bundles/aos/css").Include(
                    "~/assets/css/aos.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/bootstrap-datepicker/css").Include(
                    "~/assets/css/bootstrap-datepicker.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/bootstrap.min/css").Include(
                    "~/assets/css/bootstrap.min.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/jquery-ui/css").Include(
                    "~/assets/css/jquery-ui.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/jquery.fancybox.min/css").Include(
                    "~/assets/css/jquery.fancybox.min.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/jquery.mb.YTPlayer.min/css").Include(
                    "~/assets/css/jquery.mb.YTPlayer.min.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/magnific-popup/css").Include(
                    "~/assets/css/magnific-popup.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/mediaelementplayer/css").Include(
                    "~/assets/css/mediaelementplayer.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/owl.carousel.min/css").Include(
                    "~/assets/css/owl.carousel.min.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/owl.theme.default.min/css").Include(
                    "~/assets/css/owl.theme.default.min.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/style/css").Include(
                    "~/assets/css/style.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/validation/css").Include(
                    "~/assets/css/validation.css", new CssRewriteUrlTransform()));


               //JS
               bundles.Add(new ScriptBundle("~/bundles/aos/js").Include(
                  "~/assets/js/aos.js"));

               bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker.min/js").Include(
                    "~/assets/js/bootstrap-datepicker.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/bootstrap.min/js").Include(
                    "~/assets/js/bootstrap.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/jquery-3.3.1.min/js").Include(
                    "~/assets/js/jquery-3.3.1.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/jquery-migrate-3.0.1.min/js").Include(
                    "~/assets/js/jquery-migrate-3.0.1.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/jquery-ui/js").Include(
                    "~/assets/js/jquery-ui.js"));

               bundles.Add(new ScriptBundle("~/bundles/jquery.countdown.min/js").Include(
                    "~/assets/js/jquery.countdown.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/jquery.easing.1.3/js").Include(
                    "~/assets/js/jquery.easing.1.3.js"));

               bundles.Add(new ScriptBundle("~/bundles/jquery.fancybox.min/js").Include(
                    "~/assets/js/jquery.fancybox.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/jquery.magnific-popup.min/js").Include(
                    "~/assets/js/jquery.magnific-popup.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/jquery.mb.YTPlayer.min/js").Include(
                    "~/assets/js/jquery.mb.YTPlayer.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/jquery.stellar.min/js").Include(
                    "~/assets/js/jquery.stellar.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/jquery.sticky/js").Include(
                    "~/assets/js/jquery.sticky.js"));

               bundles.Add(new ScriptBundle("~/bundles/main/js").Include(
                    "~/assets/js/main.js"));

               bundles.Add(new ScriptBundle("~/bundles/mediaelement-and-player.min/js").Include(
                    "~/assets/js/mediaelement-and-player.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/owl.carousel.min/js").Include(
                    "~/assets/js/owl.carousel.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/popper.min/js").Include(
                    "~/assets/js/popper.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/slick.min/js").Include(
                    "~/assets/js/slick.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/typed/js").Include(
                    "~/assets/js/typed.js"));
          }
     }
}