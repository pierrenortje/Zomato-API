﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class LocationDetailsResponse
    {
        [JsonProperty("restaurant")]
        internal ZomatoRestaurant Restaurant { get; set; }
    }

    internal sealed class LocationDetailsRootObject
    {
        [JsonProperty("popularity")]
        internal string Popularity { get; set; }

        [JsonProperty("nightlife_index")]
        internal string NightLifeIndex { get; set; }

        [JsonProperty("nearby_res")]
        internal List<string> NearbyRestaurantIDs { get; set; }

        [JsonProperty("top_cuisines")]
        internal List<string> TopCuisines { get; set; }

        [JsonProperty("location")]
        internal ZomatoLocation Location { get; set; }

        /// <summary>
        /// Number of restaurants listed.
        /// </summary>
        [JsonProperty("num_restaurant")]
        internal int RestaurantCount { get; set; }

        [JsonProperty("best_rated_restaurant")]
        internal List<LocationDetailsResponse> Restaurants { get; set; }
    }
}