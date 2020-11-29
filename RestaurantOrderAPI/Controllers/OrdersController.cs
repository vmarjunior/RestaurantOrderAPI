using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderAPI.Entities;
using RestaurantOrderAPI.Models.Requests;
using RestaurantOrderAPI.Services;

namespace RestaurantOrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        OrdersService ordersService;

        public OrdersController() => ordersService = new OrdersService();
        
        [HttpPost("PlaceOrder")]
        public Order PlaceOrder([FromBody] OrderRequest data)
        {
            return ordersService.PlaceOrder(data);
        }

    }
}
