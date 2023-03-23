using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace eUseControl.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
           AreaRegistration.RegisterAllAreas();
           RouteConfig.RegisterRoutes(RouteTable.Routes);
<<<<<<< HEAD
=======

>>>>>>> 671bf15a2cc30ed8078d91f3f87d0efbbe83fc7f
           BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}