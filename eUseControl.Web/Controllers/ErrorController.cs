using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
     public class ErrorController : BaseController
     {
          // GET: Error
          public ActionResult Index()
          {
               GetUserData();
               return View();
          }
     }
}