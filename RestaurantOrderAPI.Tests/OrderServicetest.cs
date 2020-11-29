using RestaurantOrderAPI.Entities;
using RestaurantOrderAPI.Services;
using RestaurantOrderAPI.Models.Requests;
using System;
using Xunit;
using System.Linq;

namespace RestaurantOrderAPI.Tests
{
    public class OrderServiceTest
    {
        OrdersService orderService = new OrdersService();


        [Fact]
        public void PlaceOrder_Regular()
        {
            var orderNight = orderService.PlaceOrder(
                    new OrderRequest()
                    {
                        Request = "night,1,2,2,3,4"
                    });

            Assert.Equal(1, orderNight.Dishes.First(item => item.Name == "steak").Quantity);
            Assert.Equal(2, orderNight.Dishes.First(item => item.Name == "potato").Quantity);
            Assert.Equal(1, orderNight.Dishes.First(item => item.Name == "wine").Quantity);
            Assert.Equal(1, orderNight.Dishes.First(item => item.Name == "cake").Quantity);
        }

        [Fact]
        public void PlaceOrder_Period_Invalid()
        {
            Assert.Throws<ArgumentException>(() =>
                orderService.PlaceOrder(
                    new OrderRequest()
                    {
                        Request = "invalidperiod"
                    }));
        }

        [Fact]
        public void PlaceOrder_Multiples_Morning()
        {
            var orderMorning = orderService.PlaceOrder(
                    new OrderRequest()
                    {
                        Request = "morning,1,2,3,3"
                    });
            
            Assert.Equal(2, orderMorning.Dishes.First(item => item.Name == "coffee").Quantity);
        }

        [Fact]
        public void PlaceOrder_Multiples_Night()
        {
            var orderNight = orderService.PlaceOrder(
                    new OrderRequest()
                    {
                        Request = "night,1,2,2,2,2,3,2"
                    });

            Assert.Equal(5, orderNight.Dishes.First(item => item.Name == "potato").Quantity);
        }


        [Fact]
        public void PlaceOrder_Multiples_Invalid()
        {
            var orderNight = orderService.PlaceOrder(
                    new OrderRequest()
                    {
                        Request = "night,1,3,2,3,2,3"
                    });

            Assert.Equal(0, orderNight.Dishes.First(item => item.Name == "error").Quantity);
            Assert.Equal(1, orderNight.Dishes.First(item => item.Name == "potato").Quantity);
        }

    }
}
