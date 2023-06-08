using System;
using System.Collections.Generic;
using System.Web.Mvc;
using eUseControl.BusinessLogic.BL;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Trainer;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
     public class TrainersController : BaseController
     {
          private readonly ITrainer _trainers;
          private readonly ISession _sessions;

          public TrainersController()
          {
               BussinesLogic bl = new BussinesLogic();
               _trainers = bl.GetTrainerBl();
               _sessions = bl.GetSessionBl();
          }


          public ActionResult Index()
          {
               GetUserData();

               var trainersList = _trainers.GetTrainersList();
               List<Trainer> trainers = new List<Trainer>();

               foreach (var trainer in trainersList)
               {
                    trainers.Add(new Trainer
                    {
                         Id = trainer.Id,
                         Name = trainer.Name,
                         ImageUrl = trainer.ImageUrl,
                         Age = trainer.Age,
                         Bio = trainer.Bio,
                         Number = trainer.Number,
                         Specialization = trainer.Specialization,
                         Availability = trainer.Availability,
                         Price = trainer.Price
                    });
               }


               return View(trainers);
          }

          public ActionResult Details(int id)
          {
               GetUserData();
               ViewBag.Id = id;
               var trainers = _trainers.GetSingleTrainer(id);
               var trainer = new Trainer
               {
                    Id = trainers.Id,
                    Name = trainers.Name,
                    ImageUrl = trainers.ImageUrl,
                    Age = trainers.Age,
                    Bio = trainers.Bio,
                    Number = trainers.Number,
                    Specialization = trainers.Specialization,
                    Availability = trainers.Availability,
                    Price = trainers.Price
               };
               return View(trainer);
          }
          public ActionResult Edit(int id)
          {
               GetUserData();
               GetUserId();
               GetUserLevel();
               int userId = Convert.ToInt32(ViewBag.UserId);
               if (_sessions.GetIdTrainer(userId) == id)
               {
                    var trainer = _trainers.GetSingleTrainer(id);
                    if (trainer != null)
                    {
                         var trainerData = new Trainer
                         {
                              Id = trainer.Id,
                              Name = trainer.Name,
                              ImageUrl = trainer.ImageUrl,
                              Age = trainer.Age,
                              Bio = trainer.Bio,
                              Number = trainer.Number,
                              Specialization = trainer.Specialization,
                              Availability = trainer.Availability,
                              Price = trainer.Price
                         };
                         return View(trainerData);
                    }
                    else
                         return RedirectToAction("Index", "Error");

               }
               return RedirectToAction("Index", "Error");
          }
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(Trainer trainer)
          {
               TrainersUDbTable data = new TrainersUDbTable()
               {
                    Id = trainer.Id,
                    Name = trainer.Name,
                    ImageUrl = trainer.ImageUrl,
                    Age = trainer.Age,
                    Bio = trainer.Bio,
                    Number = trainer.Number,
                    Specialization = trainer.Specialization,
                    Availability = trainer.Availability,
                    Price = trainer.Price

               };

               var subscriptionCreate = _trainers.UpdateTrainer(data);
               if (!subscriptionCreate.Status)
               {
                    ModelState.AddModelError("", subscriptionCreate.StatusMsg);
                    return RedirectToAction("Index", "Subscription");

               }
               else
               {
                    return RedirectToAction("Index", "Home");
               }
          }
     }
}