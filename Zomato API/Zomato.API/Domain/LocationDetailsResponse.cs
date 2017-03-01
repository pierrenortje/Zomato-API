using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class LocationDetailsResponse
    {
        [JsonProperty("restaurant")]
        internal ZomatoRestaurant Restaurant { get; set; }
    }

    internal sealed class LocationDetailsRootObject
    {
        #region Internal Properties
        [JsonProperty("popularity")]
        internal string Popularity { get; set; }

        [JsonProperty("nightlife_index")]
        internal string NightLifeIndex { get; set; }

        [JsonProperty("nearby_res")]
        internal List<string> NearbyRestaurantIDs { get; set; }

        [JsonProperty("top_cuisines")]
        internal List<string> TopCuisines { get; set; }

        [JsonProperty("location")]
        internal ZomatoLocation Location { get; set; }

        /// <summary>
        /// Number of restaurants listed.
        /// </summary>
        [JsonProperty("num_restaurant")]
        internal int RestaurantCount { get; set; }

        [JsonProperty("best_rated_restaurant")]
        internal List<LocationDetailsResponse> Restaurants { get; set; }
        #endregion

        #region Internal Methods
        internal LocationDetails ToServiceObject()
        {
            var locationDetails = new LocationDetails
            {
                Location = new Location
                {
                    EntityType = this.Location.EntityType,
                    Longitude = this.Location.Longitude,
                    Latitude = this.Location.Latitude,
                    Title = this.Location.Title,
                    City = new City
                    {
                        ID = this.Location.CityID,
                        Name = this.Location.CityName,
                        Country = new Country
                        {
                            Name = this.Location.CountryName
                        }
                    }
                },
                Popularity = new Popularity
                {
                    PopularityRating = this.Popularity,
                    NightlifeIndex = this.NightLifeIndex,
                    NearbyRestaurantIDs = this.NearbyRestaurantIDs,
                    TopCuisines = this.TopCuisines
                },
                RestaurantCount = this.RestaurantCount
            };

            if (this.Restaurants.Count > 0)
            {
                locationDetails.BestRatedRestaurantList = new Restaurants();

                foreach (var zomatoRestaurant in this.Restaurants)
                    locationDetails.BestRatedRestaurantList.Add(zomatoRestaurant.Restaurant.ToServiceObject());
            }

            return locationDetails;
        }
        #endregion
    }
}