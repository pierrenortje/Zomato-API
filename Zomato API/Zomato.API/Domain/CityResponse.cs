using Newtonsoft.Json;

namespace Zomato.API.Domain
{
    internal sealed class CitiesRootObject
    {
        [JsonProperty("location_suggestions")]
        internal ZomatoCities LocationSuggestions { get; set; }

        [JsonProperty("status")]
        internal string Status { get; set; }

        [JsonProperty("has_more")]
        internal int HasMore { get; set; }

        [JsonProperty("has_total")]
        internal int HasTotal { get; set; }
    }
}