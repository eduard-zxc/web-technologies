using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class ScheduleController : BaseController
    {

        public ActionResult Index()
        {

            GetUserData();

            return View();

        }
    }
}