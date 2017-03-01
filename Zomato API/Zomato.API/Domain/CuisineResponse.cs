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
        #region Internal Properties
        [JsonProperty("cuisines")]
        internal List<CuisinesResponse> Cuisines { get; set; }
        #endregion

        #region Internal Methods
        internal Cuisines ToServiceObject()
        {
            var cuisines = new Cuisines();

            foreach (var cuisine in this.Cuisines)
                cuisines.Add(new Cuisine
                {
                    ID = cuisine.Cuisines.ID,
                    Name = cuisine.Cuisines.Name
                });

            return cuisines;
        }
        #endregion
    }
}