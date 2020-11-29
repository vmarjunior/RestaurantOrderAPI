using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrderAPI.Entities.Context
{
    public class RestaurantOrderContext : DbContext
    {
        public RestaurantOrderContext(DbContextOptions<RestaurantOrderContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDish> OrderDishes { get; set; }

    }
}
