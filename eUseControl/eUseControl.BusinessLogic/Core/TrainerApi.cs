using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Trainer;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Core
{
     public class TrainerApi
     {
          internal int TrainerCreateAction()
          {
               TrainersUDbTable result = new TrainersUDbTable()
               {
                    Name = "",
                    ImageUrl = "",
                    Age = 0,
                    Bio = "",
                    Number = 0,
                    Specialization = "",
                    Availability = "",
                    Price = 0
               };
               using (var db = new UserContext())
               {
                    db.Trainers.Add(result);
                    db.SaveChanges();

               }
               return result.Id;
          }

          internal List<TrainerData> GetTrainerListAction()
          {
               List<TrainerData> trainers = new List<TrainerData>();
               using (var db = new UserContext())
               {
                    var result = db.Trainers
                         .OrderBy(f => f.Id)
                         .ToList();
                    for (int i = 0; i < result.Count; i++)
                    {
                         trainers.Add(new TrainerData()
                         {
                              
                              Id= result[i].Id,

                              Name=  result[i].Name,

                              ImageUrl= result[i].ImageUrl,

                              Age = result[i].Age,

                              Bio = result[i].Bio,

                              Number = result[i].Number,

                              Specialization = result[i].Specialization,

                              Availability = result[i].Availability,

                              Price = result[i].Price
                         });
                    }
                    return trainers;
               }

          }

          internal TrainersUDbTable GetSingleTrainerAction(int id)
          {
               using (var db = new UserContext())
               {
                    return db.Trainers.FirstOrDefault(p => p.Id == id);
               }
          }

          internal PostResponse UpdateTrainerAction(TrainersUDbTable trainer)
          {
               using (var db = new UserContext())
               {
                    var tableTrainer = db.Trainers.FirstOrDefault(item => item.Id == trainer.Id);
                    if (tableTrainer == null)
                    {
                         return new PostResponse { Status = false, StatusMsg = "Error,Such a Trainer does not exist" };
                    }
                    else
                    {
                         if (trainer.Name != null && trainer.Name != tableTrainer.Name)
                         {
                              tableTrainer.Name = trainer.Name;
                         }
                         if (trainer.ImageUrl != null && trainer.ImageUrl != tableTrainer.ImageUrl)
                         {
                              tableTrainer.ImageUrl = trainer.ImageUrl;
                         }
                         if (trainer.Age != tableTrainer.Age)
                         {
                              tableTrainer.Age = trainer.Age;
                         }
                         if (trainer.Bio != null && trainer.Bio != tableTrainer.Bio)
                         {
                              tableTrainer.Bio = trainer.Bio;
                         }
                         if (trainer.Number != tableTrainer.Number)
                         {
                              tableTrainer.Number = trainer.Number;
                         }
                         if (trainer.Specialization != null && trainer.Specialization != tableTrainer.Specialization)
                         {
                              tableTrainer.Specialization = trainer.Specialization;
                         }
                         if (trainer.Availability != null && trainer.Availability != tableTrainer.Availability)
                         {
                              tableTrainer.Availability = trainer.Availability;
                         }
                         if (trainer.Price != tableTrainer.Price)
                         {
                              tableTrainer.Price = trainer.Price;
                         }
                         db.Entry(tableTrainer).State = EntityState.Modified;
                         db.SaveChanges();
                    }
               }

               return new PostResponse() { Status = true, StatusMsg = "Trainer Updated" };
          }
     }
}
