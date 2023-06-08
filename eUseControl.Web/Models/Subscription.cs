namespace eUseControl.Web.Models
{
     public class Subscription
     {
          public int Id { get; set; }
          public string Name { get; set; }
          public string Description { get; set; }
          public int PricePerMonth { get; set; }

          public string ImageUrl { get; set; }
     }
}