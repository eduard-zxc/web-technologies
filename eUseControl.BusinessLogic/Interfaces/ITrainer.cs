using System.Collections.Generic;
using eUseControl.Domain.Entities.Trainer;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface ITrainer
     {
          int TrainerCreate();
          List<TrainerData> GetTrainersList();

          TrainersUDbTable GetSingleTrainer(int? id);

          PostResponse UpdateTrainer(TrainersUDbTable trainer);
     }
}