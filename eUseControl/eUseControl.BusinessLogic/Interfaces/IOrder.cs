using eUseControl.Domain.Entities.Order;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface IOrder
     {
          PostResponse CreateOrder(OrderDbTable order);

          OrderDbTable GetOrderByTrainerId(int id);

          OrderDbTable GetOrderByUserId(int id);

          void CheckExpiration();

     }
}
