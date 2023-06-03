using System.Web.Mvc;
using eUseControl.BusinessLogic.BL;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;

namespace eUseControl.Web.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly ITrainer _trainers;

        public ProfileController()
        {
            BussinesLogic bl = new BussinesLogic();
            _trainers = bl.GetTrainerBl();
        }
        public ActionResult Index()
        {
            GetUserData();

            var user = (UserMinimal)System.Web.HttpContext.Current?.Session["__SessionObject"];
            if (user != null && user.Level == URole.Trainer)
            {
                return RedirectToAction("TrainerProfile", "Profile");
            }
            else
            {
                return RedirectToAction("UserProfile", "Profile");
            }
        }

        public ActionResult TrainerProfile(int id)
        {
            GetUserData();

            //     var trainer = _trainers.GetSingleTrainer(id);

            return View();
        }

        public ActionResult UserProfile()
        {
            GetUserData();

            return View();
        }
    }
}