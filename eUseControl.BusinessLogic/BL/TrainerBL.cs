using System.Collections.Generic;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Trainer;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.BL
{
     internal class TrainerBl : TrainerApi, ITrainer
     {
          public int TrainerCreate()
          {
               return TrainerCreateAction();
          }

          public List<TrainerData> GetTrainersList()
          {
               return GetTrainerListAction();
          }

          public TrainersUDbTable GetSingleTrainer(int? id)
          {
               return GetSingleTrainerAction(id);
          }

          public PostResponse UpdateTrainer(TrainersUDbTable trainer)
          {
               return UpdateTrainerAction(trainer);
          }
     }
}