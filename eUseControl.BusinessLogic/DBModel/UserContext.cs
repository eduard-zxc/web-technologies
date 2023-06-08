using System.Data.Entity;
using eUseControl.Domain.Entities.Subscription;
using eUseControl.Domain.Entities.Trainer;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.Feedback;
using eUseControl.Domain.Entities.Order;
using eUseControl.Domain.Entities.SubscriptionDuration;

namespace eUseControl.BusinessLogic.DBModel
{
     public class UserContext : DbContext
     {
          public UserContext() :
               base("name=eUseControl")
          {
          }
          public virtual DbSet<SessionsDb> Sessions { get; set; }
          public virtual DbSet<UDbTable> Users { get; set; }
          public virtual DbSet<SubscriptionUDbTable> Subscriptions { get; set; }
          public virtual DbSet<TrainersUDbTable> Trainers { get; set; }
          public virtual DbSet<FeedbackUDbTable> Feedback { get; set; }
          public virtual DbSet<OrderDbTable> Orders { get; set; }
          public virtual DbSet<SubscriptionDurationDbTable> SubscriptionsDuration { get; set; }
     }
}