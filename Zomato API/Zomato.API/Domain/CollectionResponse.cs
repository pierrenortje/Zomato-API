using Newtonsoft.Json;
using System.Collections.Generic;


namespace Zomato.API.Domain
{
    internal sealed class Restaurants
    {
        [JsonProperty("collection_id")]
        public int Collection_id { get; set; }

        [JsonProperty("res_count")]
        public int Res_count { get; set; }

        [JsonProperty("image_url")]
        public string Image_url { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("share_url")]
        public string Share_url { get; set; }
    }

    internal sealed class RestaurantCollection
    {
        [JsonProperty("collection")]
        public Restaurants Restaurants { get; set; }
    }

    internal sealed class CollectionRootObject
    {
        [JsonProperty("collections")]
        public List<RestaurantCollection> RestaurantCollection { get; set; }

        [JsonProperty("has_more")]
        public int Has_more { get; set; }

        [JsonProperty("share_url")]
        public string Share_url { get; set; }

        [JsonProperty("display_text")]
        public string Display_text { get; set; }

        [JsonProperty("has_total")]
        public int Has_total { get; set; }
    }
}
