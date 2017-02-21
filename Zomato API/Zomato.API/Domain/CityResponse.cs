using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class Location
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country_id")]
        public int CountryID { get; set; }

        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        [JsonProperty("should_experiment_with")]
        public int ShouldExperimentWith { get; set; }

        [JsonProperty("discovery_enabled")]
        public int DiscoveryEnabled { get; set; }

        [JsonProperty("has_new_ad_format")]
        public int HasNewAdFormat { get; set; }

        [JsonProperty("is_state")]
        public int IsState { get; set; }

        [JsonProperty("state_id")]
        public int StateID { get; set; }

        [JsonProperty("state_name")]
        public string StateName { get; set; }

        [JsonProperty("state_code")]
        public string StateCode { get; set; }
    }

    internal sealed class Locations : List<Location> { }

    internal sealed class CitiesRootObject
    {
        [JsonProperty("location_suggestions")]
        public Locations Locations { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("has_more")]
        public int HasMore { get; set; }

        [JsonProperty("has_total")]
        public int HasTotal { get; set; }
    }
}