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
        [JsonProperty("daily_menu")]
        internal List<DailyMenuResponse> DailyMenus { get; set; }
    }
}