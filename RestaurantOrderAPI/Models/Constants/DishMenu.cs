using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrderAPI.Models.Constants
{
    public static class DishMenu
    {
        static DishMenu()
        {
            DishList = new List<DishItem>();

            DishList.Add(new DishItem(PeriodType.Morning, DishType.Entrée, "eggs", 1, false));
            DishList.Add(new DishItem(PeriodType.Morning, DishType.Side, "toast", 2, false));
            DishList.Add(new DishItem(PeriodType.Morning, DishType.Drink, "coffee", 3, true));
            DishList.Add(new DishItem(PeriodType.Morning, DishType.Dessert, "error", 4, false));

            DishList.Add(new DishItem(PeriodType.Night, DishType.Entrée, "steak", 1, false));
            DishList.Add(new DishItem(PeriodType.Night, DishType.Side, "potato", 2, true));
            DishList.Add(new DishItem(PeriodType.Night, DishType.Drink, "wine", 3, false));
            DishList.Add(new DishItem(PeriodType.Night, DishType.Dessert, "cake", 4, false));
        }

        public static IList<DishItem> DishList { get; set; }
    }

    public class DishItem
    {
        public DishItem(PeriodType period, DishType type, string name, int number, bool allowMultiple)
        {
            Period = period;
            Type = type;
            Name = name;
            Number = number;
            AllowMultiple = allowMultiple;
        }

        public PeriodType Period { get; set; }
        public DishType Type { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public bool AllowMultiple { get; set; }
    }

}
