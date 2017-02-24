using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class Dish
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
    public sealed class Dishes : List<Dish> { }

    public sealed class DailyMenu
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public Dishes Dishes { get; set; }
    }

    public sealed class DailyMenus : List<DailyMenu> { }
}