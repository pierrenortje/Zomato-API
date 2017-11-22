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

using RestSharp.Deserializers;
using System.Collections.Generic;

namespace Zomato.API.Models
{
    public class DailyMenuData
    {
        [DeserializeAs(Name = "daily_menu")]
        public List<DailyMenu> DailyMenus { get; set; }
    }

    public class DailyMenu
    {
        [DeserializeAs(Name = "daily_menu_id")]
        public string ID { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "start_date")]
        public string StartDate { get; set; }

        [DeserializeAs(Name = "end_date")]
        public string EndDate { get; set; }

        [DeserializeAs(Name = "dishes")]
        public List<Dish> Dishes { get; set; }
    }

    public class Dish
    {
        [DeserializeAs(Name = "dish_id")]
        public string ID { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "price")]
        public string Price { get; set; }
    }
}
