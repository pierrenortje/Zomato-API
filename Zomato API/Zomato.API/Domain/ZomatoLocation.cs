using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class ZomatoLocation
    {
        [JsonProperty("entity_type")]
        internal string EntityType { get; set; }

        [JsonProperty("entity_id")]
        internal int EntityID { get; set; }

        [JsonProperty("title")]
        internal string Title { get; set; }

        [JsonProperty("latitude")]
        internal string Latitude { get; set; }

        [JsonProperty("longitude")]
        internal string Longitude { get; set; }

        [JsonProperty("city_id")]
        internal int CityID { get; set; }

        [JsonProperty("city_name")]
        internal string CityName { get; set; }

        [JsonProperty("country_id")]
        internal int CountryID { get; set; }

        [JsonProperty("country_name")]
        internal string CountryName { get; set; }
    }

    internal sealed class ZomatoLocations : List<ZomatoLocation> { }
}