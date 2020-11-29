using RestaurantOrderAPI.Models.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOrderAPI.Entities
{
    public class Order
    {
        public Order()
        {
            Dishes = new List<OrderDish>();
        }

        public PeriodType Period { get; set; }
        public List<OrderDish> Dishes { get; set; }
    }
}
