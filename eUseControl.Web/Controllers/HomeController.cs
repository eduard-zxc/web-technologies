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
        // GET: Home
        public ActionResult Index()
        {
            UserData u = new UserData();
            u.Username = "Costumer";
            u.Products = new List<string> { "Product #1", "Product #2", "Product #3", "Product #4" };
           
            return View(u);
        }



        public ActionResult Product()
        {
            var product = Request.QueryString["p"];

            UserData u = new UserData();
            u.Username = "Costumer";
            u.SingleProduct = product;

            return View(u);
        }
        [HttpPost]
        public ActionResult Product(string btn)
        {
            return RedirectToAction("Product", "Home", new { @p = btn });
        }
    }
}