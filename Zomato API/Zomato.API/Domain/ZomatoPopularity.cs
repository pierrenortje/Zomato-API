using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class ZomatoPopularity
    {
        [JsonProperty("popularity")]
        internal string PopularityRating { get; set; }

        [JsonProperty("nightlife_index")]
        internal string NightlifeIndex { get; set; }

        /// <summary>
        /// List of nearby restaurants' IDs.
        /// </summary>
        [JsonProperty("nearby_res")]
        internal List<string> NearbyRestaurantIDs { get; set; }

        [JsonProperty("top_cuisines")]
        internal List<string> TopCuisines { get; set; }

        [JsonProperty("popularity_res")]
        internal string TotalPopularityRestaurants { get; set; }

        [JsonProperty("nightlife_res")]
        internal string NightlifeRestaurants { get; set; }

        [JsonProperty("subzone")]
        internal string SubzoneName { get; set; }

        [JsonProperty("subzone_id")]
        internal int SubzoneID { get; set; }

        [JsonProperty("city")]
        internal string CityName { get; set; }
    }
}