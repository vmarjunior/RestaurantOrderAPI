using RestaurantOrderAPI.Entities;
using RestaurantOrderAPI.Models.Constants;
using RestaurantOrderAPI.Models.Requests;

namespace RestaurantOrderAPI.Interfaces
{
    public interface IOrdersService
    {
        Order PlaceOrder(OrderRequest orderRequest);
    }
}
