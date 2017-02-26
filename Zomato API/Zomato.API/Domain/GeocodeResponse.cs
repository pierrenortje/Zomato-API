using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class NearbyRestaurants
    {
        [JsonProperty("restaurant")]
        internal ZomatoRestaurant Restaurants { get; set; }
    }

    internal sealed class GeocodeRootObject
    {
        [JsonProperty("location")]
        internal ZomatoLocation Location { get; set; }

        [JsonProperty("popularity")]
        internal ZomatoPopularity Popularity { get; set; }

        /// <summary>
        /// URL of the web search page of the locality.
        /// </summary>
        [JsonProperty("link")]
        internal string Link { get; set; }

        [JsonProperty("nearby_restaurants")]
        internal List<NearbyRestaurants> Restaurants { get; set; }
    }
}