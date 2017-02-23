using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zomato.API.Domain
{
    public class Area
    {
        public string entity_type { get; set; }
        public int entity_id { get; set; }
        public string title { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int city_id { get; set; }
        public string city_name { get; set; }
        public int country_id { get; set; }
        public string country_name { get; set; }
    }

    public class Popularity
    {
        public string popularity { get; set; }
        public string nightlife_index { get; set; }
        public List<string> nearby_res { get; set; }
        public List<string> top_cuisines { get; set; }
        public string popularity_res { get; set; }
        public string nightlife_res { get; set; }
        public string subzone { get; set; }
        public int subzone_id { get; set; }
        public string city { get; set; }
    }

    public class R
    {
        public int res_id { get; set; }
    }

    public class Location2
    {
        public string address { get; set; }
        public string locality { get; set; }
        public string city { get; set; }
        public int city_id { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string zipcode { get; set; }
        public int country_id { get; set; }
        public string locality_verbose { get; set; }
    }

    public class UserRating
    {
        public string aggregate_rating { get; set; }
        public string rating_text { get; set; }
        public string rating_color { get; set; }
        public string votes { get; set; }
    }

    public class Restaurant
    {
        public R R { get; set; }
        public string apikey { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Location2 location { get; set; }
        public int switch_to_order_menu { get; set; }
        public string cuisines { get; set; }
        public int average_cost_for_two { get; set; }
        public int price_range { get; set; }
        public string currency { get; set; }
        public List<object> offers { get; set; }
        public string thumb { get; set; }
        public UserRating user_rating { get; set; }
        public string photos_url { get; set; }
        public string menu_url { get; set; }
        public string featured_image { get; set; }
        public int has_online_delivery { get; set; }
        public int is_delivering_now { get; set; }
        public string deeplink { get; set; }
        public int has_table_booking { get; set; }
        public string events_url { get; set; }
    }

    public class NearbyRestaurant
    {
        public Restaurant restaurant { get; set; }
    }

    public class GeocodeRootObject
    {
        public Area area { get; set; }
        public Popularity popularity { get; set; }
        public string link { get; set; }
        public List<NearbyRestaurant> nearby_restaurants { get; set; }
    }
}
