using System.Threading.Tasks;
using Zomato.API.Domain;

namespace Zomato.API
{
    public sealed partial class ZomatoService
    {
        #region Private Fields
        private WebRequest webRequest = null;
        #endregion

        #region Constructor
        public ZomatoService()
        {
            webRequest = new WebRequest();
        }
        #endregion

        #region Private Async Methods
        private async Task<Cities> SelectCitiesAsync(string queryText, double? latitude, double? longitude, int[] cityIDs, int? count)
        {
            Cities cities = null;
            CitiesRootObject citiesResponse = null;

            citiesResponse = await webRequest.SelectCitiesAsync(queryText, latitude, longitude, cityIDs, count);

            if (citiesResponse?.LocationSuggestions == null)
                return cities;

            cities = new Cities();

            foreach (var city in citiesResponse.LocationSuggestions)
            {
                var country = new Country
                {
                    ID = city.CountryID,
                    Name = city.CountryName
                };

                cities.Add(new City
                {
                    ID = city.ID,
                    Name = city.Name,
                    Country = country
                });
            }

            return cities;
        }

        private async Task<Collections> SelectCollectionsAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            Collections collections = null;
            CollectionsRootObject collectionResponse = null;

            collectionResponse = await webRequest.SelectCollectionsAsync(cityID, latitude, longitude, count);

            if (collectionResponse?.Collections == null)
                return collections;

            collections = new Collections();

            foreach (var restaurant in collectionResponse.Collections)
            {
                collections.Add(new Collection
                {
                    ID = restaurant.Collections.ID,
                    Title = restaurant.Collections.Title,
                    Url = restaurant.Collections.Url,
                    Description = restaurant.Collections.Description
                });
            }

            collections.ShareUrl = collectionResponse.ShareUrl;

            return collections;
        }

        private async Task<Cuisines> SelectCuisinesAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            Cuisines cuisines = null;
            CuisinesRootObject cuisinesResponse = null;

            cuisinesResponse = await webRequest.SelectCuisinesAsync(cityID, latitude, longitude, count);

            if (cuisinesResponse?.Cuisines == null)
                return cuisines;

            cuisines = new Cuisines();

            foreach (var cuisine in cuisinesResponse.Cuisines)
                cuisines.Add(new Cuisine
                {
                    ID = cuisine.Cuisines.ID,
                    Name = cuisine.Cuisines.Name
                });

            return cuisines;
        }

        private async Task<Establishments> SelectEstablishmentsAsync(int? cityID, double? latitude, double? longitude)
        {
            Establishments establishments = null;
            EstablishmentsRootObject establishmentsResponse = null;

            establishmentsResponse = await webRequest.SelectEstablishmentsAsync(cityID, latitude, longitude);

            if (establishmentsResponse?.Establishments == null)
                return establishments;

            establishments = new Establishments();

            foreach (var establishment in establishmentsResponse.Establishments)
                establishments.Add(new Establishment
                {
                    ID = establishment.Establishments.ID,
                    Name = establishment.Establishments.Name
                });

            return establishments;
        }

        private async Task<Geocode> SelectGeocodeAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            Geocode geocode = null;
            GeocodeRootObject geocodeResponse = null;

            geocodeResponse = await webRequest.SelectGeocodeAsync(latitude, longitude);

            if (geocodeResponse == null)
                return geocode;

            geocode = new Geocode
            {
                Location = new Location
                {
                    City = new City
                    {
                        ID = geocodeResponse.Location.CityID,
                        Name = geocodeResponse.Location.CityName,
                        Country = new Country
                        {
                            ID = geocodeResponse.Location.CountryID,
                            Name = geocodeResponse.Location.CountryName
                        }
                    },
                    Latitude = geocodeResponse.Location.Latitude,
                    Longitude = geocodeResponse.Location.Longitude,
                    Title = geocodeResponse.Location.Title
                },
                Link = geocodeResponse.Link,
                Popularity = new Popularity
                {
                    City = new City
                    {
                        Name = geocodeResponse.Popularity.CityName
                    },
                    SubZone = new SubZone
                    {
                        ID = geocodeResponse.Popularity.SubZoneID,
                        Name = geocodeResponse.Popularity.SubZoneName
                    },
                    NearbyRestaurantIDs = geocodeResponse.Popularity.NearbyRestaurantIDs,
                    NightlifeIndex = geocodeResponse.Popularity.NightlifeIndex,
                    NightlifeRestaurants = geocodeResponse.Popularity.NightlifeRestaurants,
                    PopularityRating = geocodeResponse.Popularity.PopularityRating,
                    TopCuisines = geocodeResponse.Popularity.TopCuisines,
                    TotalPopularityRestaurants = geocodeResponse.Popularity.TotalPopularityRestaurants
                },
                NearbyRestaurantList = new NearbyRestaurantList()
            };

            foreach (var zomatoRestaurant in geocodeResponse.Restaurants)
                geocode.NearbyRestaurantList.Add(zomatoRestaurant.Restaurants.ToZomatoObject());

            return geocode;
        }
        #endregion
    }
}