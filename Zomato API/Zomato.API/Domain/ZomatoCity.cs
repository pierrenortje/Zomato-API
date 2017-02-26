using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal class ZomatoCity
    {
        [JsonProperty("id")]
        internal int ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("country_id")]
        internal int CountryID { get; set; }

        [JsonProperty("country_name")]
        internal string CountryName { get; set; }

        [JsonProperty("is_state")]
        internal int IsState { get; set; }

        [JsonProperty("state_id")]
        internal int StateID { get; set; }

        [JsonProperty("state_name")]
        internal string StateName { get; set; }

        [JsonProperty("state_code")]
        internal string StateCode { get; set; }
    }

    internal sealed class ZomatoCities : List<ZomatoCity> { }
}