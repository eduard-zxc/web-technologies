using AutoMapper;
using System;
using System.Web.Mvc;
using eUseControl.Domain.Entities.Feedback;
using eUseControl.BusinessLogic.DBModel;

namespace eUseControl.Web.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: /Feedback/Index
        public ActionResult Index()
        {
            return View();
        }

        // POST: /Feedback/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FeedbackModel model)
        {
            if (ModelState.IsValid)
            {
                // Assign the current datetime if not provided by the user////////////////////////////////////////////////////////////////////////////
                if (model.Time == default(DateTime))
                {
                    model.Time = DateTime.UtcNow; // Assign the current UTC datetime
                }/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Save the feedback to the database
                SaveFeedbackToDatabase(model);

                return RedirectToAction("ThankYou");
            }

            return View();

        }

        // GET: /Feedback/ThankYou
        public ActionResult ThankYou()
        {
            return View();
        }

        private void SaveFeedbackToDatabase(FeedbackModel model)
        {
            // Create AutoMapper mapping configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FeedbackModel, FeedbackUDbTable>();
            });

            // Create the mapper instance
            IMapper mapper = config.CreateMapper();

            // Map the FeedbackModel to the FeedbackUDbTable entity
            var feedbackEntity = mapper.Map<FeedbackUDbTable>(model);

            // Save the feedback to the database using your data access layer or ORM
            // Example using Entity Framework:
            using (var dbContext = new UserContext())
            {
                dbContext.Feedback.Add(feedbackEntity);
                dbContext.SaveChanges();
            }
        }
    }
}
