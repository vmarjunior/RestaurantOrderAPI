using RestaurantOrderAPI.Models.Constants;

namespace RestaurantOrderAPI.Entities
{
    public class OrderDish
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DishType Type { get; set; }
        public bool AllowMultiple { get; set; }
        public int Number { get; set; }
    }
}
