using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class DishResponse
    {
        [JsonProperty("dish_id")]
        internal string ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("price")]
        internal string Price { get; set; }
    }

    internal sealed class DailyMenuResponse
    {
        [JsonProperty("daily_menu_id")]
        internal string ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("start_date")]
        internal string StartDate { get; set; }

        [JsonProperty("end_date")]
        internal string EndDate { get; set; }

        [JsonProperty("dishes")]
        internal List<DishResponse> Dishes { get; set; }
    }

    internal sealed class DailyMenuRootObject
    {
        #region Internal Properties
        [JsonProperty("daily_menu")]
        internal List<DailyMenuResponse> DailyMenus { get; set; }
        #endregion

        #region Internal Methods
        internal DailyMenus ToServiceObject()
        {
            var dailyMenus = new DailyMenus();

            foreach (var dailyMenu in this.DailyMenus)
            {
                var dailyMenuItem = new DailyMenu
                {
                    ID = dailyMenu.ID,
                    Name = dailyMenu.Name,
                    StartDate = dailyMenu.StartDate,
                    EndDate = dailyMenu.EndDate
                };

                foreach (var dish in dailyMenu.Dishes)
                    dailyMenuItem.Dishes.Add(new Dish
                    {
                        ID = dish.ID,
                        Name = dish.Name,
                        Price = dish.Price
                    });

                dailyMenus.Add(dailyMenuItem);
            }

            return dailyMenus;
        }
        #endregion
    }
}