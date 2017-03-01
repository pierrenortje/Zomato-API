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

            collections = collectionResponse.ToServiceObject();

            return collections;
        }

        private async Task<Cuisines> SelectCuisinesAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            Cuisines cuisines = null;
            CuisinesRootObject cuisinesResponse = null;

            cuisinesResponse = await webRequest.SelectCuisinesAsync(cityID, latitude, longitude, count);

            if (cuisinesResponse?.Cuisines == null)
                return cuisines;

            cuisines = cuisinesResponse.ToServiceObject();

            return cuisines;
        }

        private async Task<Establishments> SelectEstablishmentsAsync(int? cityID, double? latitude, double? longitude)
        {
            Establishments establishments = null;
            EstablishmentsRootObject establishmentsResponse = null;

            establishmentsResponse = await webRequest.SelectEstablishmentsAsync(cityID, latitude, longitude);

            if (establishmentsResponse?.Establishments == null)
                return establishments;

            establishments = establishmentsResponse.ToServiceObject();

            return establishments;
        }

        private async Task<Geocode> SelectGeocodeAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            Geocode geocode = null;
            GeocodeRootObject geocodeResponse = null;

            geocodeResponse = await webRequest.SelectGeocodeAsync(latitude, longitude);

            if (geocodeResponse == null)
                return geocode;

            geocode = geocodeResponse.ToServiceObject();

            return geocode;
        }
        #endregion
    }
}