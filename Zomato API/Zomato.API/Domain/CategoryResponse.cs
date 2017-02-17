using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class CategoryResponse
    {
        [JsonProperty("category_id")]
        public string ID { get; set; }

        [JsonProperty("category_name")]
        public string Name { get; set; }
    }

    internal sealed class CategoriesResponse : List<CategoryResponse> { }
}