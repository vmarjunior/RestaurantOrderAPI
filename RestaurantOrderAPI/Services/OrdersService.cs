using RestaurantOrderAPI.Entities;
using RestaurantOrderAPI.Interfaces;
using RestaurantOrderAPI.Models.Constants;
using RestaurantOrderAPI.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrderAPI.Services
{
    public class OrdersService : IOrdersService
    {
        public Order PlaceOrder(OrderRequest orderRequest)
        {
            Order order = new Order();
            order.Period = GetOrderPeriod(orderRequest.Request);
            order.Dishes = GetOrderDishes(order.Period, orderRequest.Request);
            return order;
        }

        private PeriodType GetOrderPeriod(string request)
        {
            if (request?.ToLower().Contains("morning") ?? false)
                return PeriodType.Morning;
            else if (request?.ToLower().Contains("night") ?? false)
                return PeriodType.Night;

            throw new ArgumentException("Period invalid. Accepted values: (morning, night).");
        }

        private List<OrderDish> GetOrderDishes(PeriodType periodType, string request)
        {
            var requestedDishes = request.ToLower().Split(',').ToList();

            //Removes the period
            requestedDishes.RemoveAt(0);

            List<OrderDish> orderDishes = new List<OrderDish>();

            foreach (var requestDish in requestedDishes)
            {
                var dishNumber = Convert.ToInt32(requestDish);

                var included = orderDishes.FirstOrDefault(x => x.Number == dishNumber);

                if (included == null)
                {
                    var dish = GetDish(periodType, dishNumber);
                    if (dish != null)
                        orderDishes.Add(dish);
                    else
                    {
                        orderDishes.Add(new OrderDish() { Name = "error", Type = DishType.Error });
                        break;
                    }
                }
                else
                {
                    if (included.AllowMultiple)
                        included.Quantity++;
                    else
                    {
                        orderDishes.Add(new OrderDish() { Name = "error", Type = DishType.Error });
                        break;
                    }
                }
            }

            return orderDishes.OrderBy(o => o.Type).ToList();
        }

        private OrderDish GetDish(PeriodType periodType, int dishNumber)
        {
            var dish = DishMenu.DishList.FirstOrDefault(i => i.Period == periodType && i.Number == dishNumber);

            if (dish == null)
                return null;

            return new OrderDish()
            {
                Name = dish.Name,
                Number = dish.Number,
                Quantity = 1,
                Type = dish.Type,
                AllowMultiple = dish.AllowMultiple
            };
        }


    }
}
