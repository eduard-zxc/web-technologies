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
                    var result = db.Trainers.ToList();
                    foreach (var item in result)
                    {
                         trainers.Add(new TrainerData()
                         {

                              Id= item.Id,

                              Name=  item.Name,

                              ImageUrl= item.ImageUrl,

                              Age = item.Age,

                              Bio = item.Bio,

                              Number = item.Number,

                              Specialization = item.Specialization,

                              Availability = item.Availability,

                              Price = item.Price
                         });
                    }
                    return trainers;
               }

          }

          internal TrainersUDbTable GetSingleTrainerAction(int? id)
          {
               if (id != null)
               {
                    using (var db = new UserContext())
                    {
                         return db.Trainers.FirstOrDefault(p => p.Id == id);
                    }
               }
               return null;
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

                         tableTrainer.Name = trainer.Name;
                         tableTrainer.ImageUrl = trainer.ImageUrl;
                         tableTrainer.Age = trainer.Age;
                         tableTrainer.Bio = trainer.Bio;
                         tableTrainer.Number = trainer.Number;
                         tableTrainer.Specialization = trainer.Specialization;
                         tableTrainer.Availability = trainer.Availability;
                         tableTrainer.Price = trainer.Price;
                         db.Entry(tableTrainer).State = EntityState.Modified;
                         db.SaveChanges();
                    }
               }

               return new PostResponse() { Status = true, StatusMsg = "Trainer Updated" };
          }
     }
}
