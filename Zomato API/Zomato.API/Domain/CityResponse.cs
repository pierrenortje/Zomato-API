using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class CityLocation
    {
        [JsonProperty("id")]
        internal int ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("country_id")]
        internal int CountryID { get; set; }

        [JsonProperty("country_name")]
        internal string CountryName { get; set; }

        [JsonProperty("should_experiment_with")]
        internal int ShouldExperimentWith { get; set; }

        [JsonProperty("discovery_enabled")]
        internal int DiscoveryEnabled { get; set; }

        [JsonProperty("has_new_ad_format")]
        internal int HasNewAdFormat { get; set; }

        [JsonProperty("is_state")]
        internal int IsState { get; set; }

        [JsonProperty("state_id")]
        internal int StateID { get; set; }

        [JsonProperty("state_name")]
        internal string StateName { get; set; }

        [JsonProperty("state_code")]
        internal string StateCode { get; set; }
    }

    internal sealed class CityLocations : List<CityLocation> { }

    internal sealed class CitiesRootObject
    {
        [JsonProperty("location_suggestions")]
        internal CityLocations Locations { get; set; }

        [JsonProperty("status")]
        internal string Status { get; set; }

        [JsonProperty("has_more")]
        internal int HasMore { get; set; }

        [JsonProperty("has_total")]
        internal int HasTotal { get; set; }
    }
}