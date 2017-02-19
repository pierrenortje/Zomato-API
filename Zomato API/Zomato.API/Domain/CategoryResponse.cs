using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class CategoryResponse
    {
        [JsonProperty("id")]
        internal int ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }
    }

    internal sealed class CategoriesResponse
    {
        [JsonProperty("categories")]
        internal CategoryResponse Categories { get; set; }
    }

    internal sealed class CategoriesRootObject
    {
        [JsonProperty("categories")]
        internal List<CategoriesResponse> Categories { get; set; }
    }
}