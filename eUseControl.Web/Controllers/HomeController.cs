using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UserData u = new UserData
            {
                Username = "customer",
                Products = new List<string> { "Product #1", "Product #2", "Product #3" }
            };

            return View(u);
        }

        public ActionResult Classes()
        {
            var product = Request.QueryString["p"];

            UserData u = new UserData();
            u.Username= "customer";
            u.SingleProduct = product;

            return View(u);
        }

        [HttpPost]
        public ActionResult Classes(string btn)
        {
            return RedirectToAction("Classes", "Home", new { @p = btn });
        }
    }
}