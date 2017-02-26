using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class Region
    {
        [JsonProperty("entity_type")]
        internal string entityType { get; set; }

        [JsonProperty("entity_id")]
        internal int entityID { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("latitude")]
        internal string latitude { get; set; }

        [JsonProperty("longitude")]
        internal string longitude { get; set; }

        [JsonProperty("city_id")]
        internal int cityID { get; set; }

        [JsonProperty("city_name")]
        public string cityName { get; set; }

        [JsonProperty("country_id")]
        internal int countryID { get; set; }

        [JsonProperty("country_name")]
        public string countryName { get; set; }
    }

    public sealed class Popularity
    {

        [JsonProperty("popularity")]
        public string popularity { get; set; }

        [JsonProperty("nightlife_index")]
        public string nightlifeIndex { get; set; }

        /// <summary>
        /// List of nearby restaurants' IDs
        /// </summary>
        [JsonProperty("nearby_res")]
        internal List<string> nearbyResIDs { get; set; }

        [JsonProperty("top_cuisines")]
        public List<string> topCuisines { get; set; }

        [JsonProperty("popularity_res")]
        internal string popularityRes { get; set; }

        [JsonProperty("nightlife_res")]
        internal string nightlifeRes { get; set; }

        [JsonProperty("subzone")]
        internal string subzone { get; set; }

        [JsonProperty("subzone_id")]
        internal int subzoneID { get; set; }

        [JsonProperty("city")]
        internal string city { get; set; }
    }

    internal sealed class R
    {
        [JsonProperty("res_id")]
        internal int resID { get; set; }
    }

    public sealed class Area
    {
        [JsonProperty("address")]
        public string address { get; set; }

        [JsonProperty("locality")]
        internal string locality { get; set; }

        [JsonProperty("city")]
        internal string city { get; set; }

        [JsonProperty("city_id")]
        internal int cityID { get; set; }

        [JsonProperty("latitude")]
        internal string latitude { get; set; }

        [JsonProperty("longitude")]
        internal string longitude { get; set; }

        [JsonProperty("zipcode")]
        internal string zipcode { get; set; }

        [JsonProperty("country_id")]
        internal int countryID { get; set; }

        [JsonProperty("locality_verbose")]
        internal string localityVerbose { get; set; }
    }

    public sealed class UserRating
    {
        [JsonProperty("aggregate_rating")]
        public string aggregateRating { get; set; }

        [JsonProperty("rating_text")]
        public string ratingText { get; set; }

        [JsonProperty("rating_color")]
        public string ratingColor { get; set; }

        [JsonProperty("votes")]
        public string votes { get; set; }
    }

    public sealed class Restaurant
    {
        [JsonProperty("R")]
        internal R R { get; set; }

        [JsonProperty("apikey")]
        internal string apikey { get; set; }

        [JsonProperty("id")]
        internal string ID { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("location")]
        public Area area { get; set; }

        [JsonProperty("switch_to_order_menu")]
        public int switchToOrderMenu { get; set; }

        [JsonProperty("cuisines")]
        public string cuisines { get; set; }

        [JsonProperty("average_cost_for_two")]
        public int averageCostForTwo { get; set; }

        [JsonProperty("price_range")]
        public int priceRange { get; set; }

        [JsonProperty("currency")]
        public string currency { get; set; }

        [JsonProperty("offers")]
        public List<object> offers { get; set; }

        [JsonProperty("thumb")]
        internal string thumb { get; set; }

        [JsonProperty("user_rating")]
        public UserRating userRating { get; set; }

        [JsonProperty("photos_url")]
        public string photosUrl { get; set; }

        [JsonProperty("menu_url")]
        public string menuUrl { get; set; }

        [JsonProperty("featured_image")]
        public string featuredImage { get; set; }

        [JsonProperty("has_online_delivery")]
        public int hasOnlineDelivery { get; set; }

        [JsonProperty("is_delivering_now")]
        public int isDeliveringNow { get; set; }

        [JsonProperty("deeplink")]
        internal string deeplink { get; set; }

        [JsonProperty("has_table_booking")]
        public int hasTableBooking { get; set; }

        [JsonProperty("events_url")]
        public string eventsUrl { get; set; }
    }

    public sealed class NearbyRestaurants
    {
        [JsonProperty("restaurant")]
        public Restaurant restaurant { get; set; }
    }

    internal sealed class GeocodeRootObject
    {
        [JsonProperty("location")]
        internal Region region { get; set; }

        [JsonProperty("popularity")]
        internal Popularity popularity { get; set; }

        [JsonProperty("link")]
        internal string link { get; set; }

        [JsonProperty("nearby_restaurants")]
        internal List<NearbyRestaurants> nearbyRestaurants { get; set; }
    }
}
