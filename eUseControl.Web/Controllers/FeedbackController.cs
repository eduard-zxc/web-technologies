using AutoMapper;
using System;
using System.Web.Mvc;
using eUseControl.Domain.Entities.Feedback;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Web.Filters;
using System.Linq;
using eUseControl.BusinessLogic.BL;
using eUseControl.BusinessLogic.Interfaces;

namespace eUseControl.Web.Controllers
{
     public class FeedbackController : BaseController
     {
          private readonly IFeedback _feedbackRepository;

          public FeedbackController()
          {
               var bl = new BussinesLogic();
               _feedbackRepository = bl.GetFeedbackBl();
          }

          // GET: /Feedback/Index
          public ActionResult Index()
          {
               GetUserData();
               return View();
          }

          // POST: /Feedback/Index
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(FeedbackModel model)
          {
               GetUserData();
               if (ModelState.IsValid)
               {
                    // Assign the current datetime if not provided by the user
                    if (model.Time == default(DateTime))
                    {
                         model.Time = DateTime.UtcNow; // Assign the current UTC datetime
                    }

                    // Save the feedback to the database
                    var feedbackEntity = MapFeedbackModelToEntity(model);
                    _feedbackRepository.SaveFeedback(feedbackEntity);

                    return RedirectToAction("ThankYou");
               }

               return View();
          }

          // GET: /Feedback/ThankYou
          public ActionResult ThankYou()
          {
               GetUserData();
               return View();
          }

          // GET: /Feedback/FeedbackList
          [AdminMod]
          public ActionResult FeedbackList()
          {
               GetUserData();
               var feedbacks = _feedbackRepository.GetFeedback();
               return View(feedbacks);
          }

          // POST: /Feedback/DeleteFeedback
          [HttpPost]
          [AdminMod]
          [ValidateAntiForgeryToken]
          public ActionResult DeleteFeedback(int id)
          {
               GetUserData();
               _feedbackRepository.DeleteFeedback(id);
               return RedirectToAction("FeedbackList");
          }

          private FeedbackUDbTable MapFeedbackModelToEntity(FeedbackModel model)
          {
               GetUserData();
               var config = new MapperConfiguration(cfg =>
               {
                    cfg.CreateMap<FeedbackModel, FeedbackUDbTable>();
               });

               IMapper mapper = config.CreateMapper();
               var feedbackEntity = mapper.Map<FeedbackUDbTable>(model);

               return feedbackEntity;
          }
     }
}