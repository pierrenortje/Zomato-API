#region License
// Copyright (c) 2017 Pierre Nortje
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

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