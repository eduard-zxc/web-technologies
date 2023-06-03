using System.Collections.Generic;
using eUseControl.Domain.Entities.Subscription;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ISubscriptionDetails
    {
        List<SubscriptionDurationData> GetAllSubscriptionDuration();

        PostResponse DeleteSubscriptionDuration(int id);

        PostResponse AddSubscriptionDuration(SubscriptionDurationDbTable subscription);
    }
}
