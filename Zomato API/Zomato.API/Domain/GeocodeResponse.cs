using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class NearbyRestaurants
    {
        [JsonProperty("restaurant")]
        internal ZomatoRestaurant Restaurants { get; set; }
    }

    internal sealed class GeocodeRootObject
    {
        #region Internal Properties
        [JsonProperty("location")]
        internal ZomatoLocation Location { get; set; }

        [JsonProperty("popularity")]
        internal ZomatoPopularity Popularity { get; set; }

        /// <summary>
        /// URL of the web search page of the locality.
        /// </summary>
        [JsonProperty("link")]
        internal string Link { get; set; }

        [JsonProperty("nearby_restaurants")]
        internal List<NearbyRestaurants> Restaurants { get; set; }
        #endregion

        #region Internal Methods
        internal Geocode ToServiceObject()
        {
            var geocode = new Geocode
            {
                Location = this.Location.ToServiceObject(),
                Link = this.Link,
                Popularity = new Popularity
                {
                    City = new City
                    {
                        Name = this.Popularity.CityName
                    },
                    Subzone = new Subzone
                    {
                        ID = this.Popularity.SubzoneID,
                        Name = this.Popularity.SubzoneName
                    },
                    NearbyRestaurantIDs = this.Popularity.NearbyRestaurantIDs,
                    NightlifeIndex = this.Popularity.NightlifeIndex,
                    NightlifeRestaurants = this.Popularity.NightlifeRestaurants,
                    PopularityRating = this.Popularity.PopularityRating,
                    TopCuisines = this.Popularity.TopCuisines,
                    TotalPopularityRestaurants = this.Popularity.TotalPopularityRestaurants
                },
                NearbyRestaurantList = new NearbyRestaurantList()
            };

            foreach (var zomatoRestaurant in this.Restaurants)
                geocode.NearbyRestaurantList.Add(zomatoRestaurant.Restaurants.ToServiceObject());

            return geocode;
        }
        #endregion
    }
}