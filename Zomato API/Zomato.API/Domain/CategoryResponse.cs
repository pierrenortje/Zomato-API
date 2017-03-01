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
        #region Internal Properties
        [JsonProperty("categories")]
        internal List<CategoriesResponse> Categories { get; set; }
        #endregion

        #region Internal Methods
        internal Categories ToServiceObject()
        {
            var categories = new Categories();

            foreach (var category in this.Categories)
                categories.Add(new Category
                {
                    ID = category.Categories.ID,
                    Name = category.Categories.Name
                });

            return categories;
        }
        #endregion
    }
}