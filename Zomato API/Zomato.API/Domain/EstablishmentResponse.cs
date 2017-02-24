using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class EstablishmentResponse
    {
        [JsonProperty("id")]
        internal int ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }
    }

    internal sealed class EstablishmentsResponse
    {
        [JsonProperty("establishment")]
        internal EstablishmentResponse Establishments { get; set; }
    }

    internal sealed class EstablishmentsRootObject
    {
        [JsonProperty("establishments")]
        internal List<EstablishmentsResponse> Establishments { get; set; }
    }
}