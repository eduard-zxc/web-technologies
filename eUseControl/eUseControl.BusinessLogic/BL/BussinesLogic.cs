﻿using eUseControl.BusinessLogic.Interfaces;

namespace eUseControl.BusinessLogic.BL
{
    public class BussinesLogic
    {
        public ISession GetSessionBl()
        {
            return new SessionBl();
        }

        public ISubscription GetSubscriptionBl()
        {
             return new SubscriptionBl();
        }

        public ITrainer GetTrainerBl()
        {
             return new TrainerBl();
        }

        public IOrder GetOrderBl()
        {
             return  new OrderBl();
        }

     }
}