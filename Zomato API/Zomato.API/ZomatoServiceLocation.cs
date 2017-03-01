using System.Threading.Tasks;
using Zomato.API.Domain;

namespace Zomato.API
{
    public sealed partial class ZomatoService
    {
        #region Public Async Methods
        /// <summary>
        /// Get Foodie Index, Nightlife Index, Top Cuisines and Best rated restaurants in a given location.
        /// </summary>
        /// <param name="locationID">ID of the location.</param>
        /// <param name="entityType">Name of the entity.</param>
        /// <returns>A list of popular cuisines and nearby restaurants around the given location.</returns>
        public async Task<LocationDetails> SelectLocationDetailsAsync(int? locationID, string entityType)
        {
            LocationDetails locationDetails = null;
            LocationDetailsRootObject locationDetailsResponse = null;

            locationDetailsResponse = await webRequest.SelectLocationDetails(locationID, entityType);

            if (locationDetailsResponse == null)
                return locationDetails;

            locationDetails = new LocationDetails
            {
                Location = new Location
                {
                    EntityType = locationDetailsResponse.Location.EntityType,
                    Longitude = locationDetailsResponse.Location.Longitude,
                    Latitude = locationDetailsResponse.Location.Latitude,
                    Title = locationDetailsResponse.Location.Title,
                    City = new City
                    {
                        ID = locationDetailsResponse.Location.CityID,
                        Name = locationDetailsResponse.Location.CityName,
                        Country = new Country
                        {
                            Name = locationDetailsResponse.Location.CountryName
                        }
                    }
                },
                Popularity = new Popularity
                {
                    PopularityRating = locationDetailsResponse.Popularity,
                    NightlifeIndex = locationDetailsResponse.NightLifeIndex,
                    NearbyRestaurantIDs = locationDetailsResponse.NearbyRestaurantIDs,
                    TopCuisines = locationDetailsResponse.TopCuisines
                },
                RestaurantCount = locationDetailsResponse.RestaurantCount,
                BestRatedRestaurantList = new Restaurants()
            };

            foreach (var zomatoRestaurant in locationDetailsResponse.Restaurants)
                locationDetails.BestRatedRestaurantList.Add(zomatoRestaurant.Restaurant.ToZomatoObject());

            return locationDetails;
        }
        #endregion
    }
}