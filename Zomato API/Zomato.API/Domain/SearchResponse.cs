using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class SearchRestaurant
    {
        [JsonProperty("restaurant")]
        internal ZomatoRestaurant Restaurant { get; set; }
    }
    internal sealed class SearchRestaurants : List<SearchRestaurant> { }

    internal sealed class SearchRootObject
    {
        #region Internal Properties
        [JsonProperty("results_found")]
        internal int ResultsFound { get; set; }

        [JsonProperty("results_start")]
        internal int ResultsStart { get; set; }

        [JsonProperty("results_shown")]
        internal int ResultsShown { get; set; }

        [JsonProperty("restaurants")]
        internal SearchRestaurants Restaurants { get; set; }
        #endregion

        #region Internal Methods
        internal SearchResult ToServiceObject()
        {
            var search = new SearchResult
            {
                Restaurants = new Domain.Restaurants()
            };

            foreach (var restaurant in this.Restaurants)
                search.Restaurants.Add(restaurant.Restaurant.ToServiceObject());

            return search;
        }
        #endregion
    }
}