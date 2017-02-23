using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class CuisineResponse
    {
        [JsonProperty("cuisine_id")]
        internal int ID { get; set; }

        [JsonProperty("cuisine_name")]
        internal string Name { get; set; }
    }

    internal sealed class CuisinesResponse
    {
        [JsonProperty("cuisine")]
        internal CuisineResponse Cuisines { get; set; }
    }

    internal sealed class CuisinesRootObject
    {
        [JsonProperty("cuisines")]
        internal List<CuisinesResponse> Cuisines { get; set; }
    }
}