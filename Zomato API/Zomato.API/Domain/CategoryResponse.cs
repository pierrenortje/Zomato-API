using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class CategoryResponse
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    internal sealed class CategoriesResponse
    {
        [JsonProperty("categories")]
        public CategoryResponse Categories { get; set; }
    }

    internal sealed class CategoriesRootObject
    {
        [JsonProperty("categories")]
        public List<CategoriesResponse> Categories { get; set; }
    }
}