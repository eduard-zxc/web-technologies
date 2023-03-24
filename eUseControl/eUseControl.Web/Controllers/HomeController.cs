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
<<<<<<< HEAD
        // GET: Home
        public ActionResult Index()
        {
            UserData u = new UserData();
            u.Username = "Costumer";
            u.Products = new List<string> { "Product #1", "Product #2", "Product #3", "Product #4" };
           
            return View(u);
        }



        public ActionResult Product()
=======
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
>>>>>>> 671bf15a2cc30ed8078d91f3f87d0efbbe83fc7f
        {
            var product = Request.QueryString["p"];

            UserData u = new UserData();
<<<<<<< HEAD
            u.Username = "Costumer";
=======
            u.Username= "customer";
>>>>>>> 671bf15a2cc30ed8078d91f3f87d0efbbe83fc7f
            u.SingleProduct = product;

            return View(u);
        }
<<<<<<< HEAD
        [HttpPost]
        public ActionResult Product(string btn)
        {
            return RedirectToAction("Product", "Home", new { @p = btn });
=======

        [HttpPost]
        public ActionResult Classes(string btn)
        {
            return RedirectToAction("Classes", "Home", new { @p = btn });
>>>>>>> 671bf15a2cc30ed8078d91f3f87d0efbbe83fc7f
        }
    }
}