﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zomato.API.Controllers;
using Zomato.API.Domain;
using Zomato.API.Util;

namespace Zomato.API
{
    internal sealed class WebRequest
    {
        #region Private Fields
        private string apiKey = ConfigurationHelper.GetApiKey();
        #endregion

        #region Private Const Fields
        private const string apiRequestUrl = "https://developers.zomato.com/api/v2.1/";
        private const string userKeyHeaderKey = "user-key";
        #endregion

        #region Private Properties
        private KeyValuePair<string, string> UserKey
        {
            get
            {
                return new KeyValuePair<string, string>(userKeyHeaderKey, apiKey);
            }
        }
        #endregion

        #region Private Methods
        private void AppendBaseParameters(ref List<KeyValuePair<string, string>> parameters, int? cityID, double? latitude, double? longitude, int? count)
        {
            if ((!latitude.HasValue && longitude.HasValue) || (latitude.HasValue && !longitude.HasValue))
                throw new Exception("You need to specify both the latitude and longitude.");

            if (latitude.HasValue && longitude.HasValue)
            {
                parameters.Add(new KeyValuePair<string, string>("lat", latitude.Value.ToString()));
                parameters.Add(new KeyValuePair<string, string>("lon", longitude.Value.ToString()));
            }

            if (cityID.HasValue)
                parameters.Add(new KeyValuePair<string, string>("city_id", cityID.ToString()));

            if (count.HasValue)
                parameters.Add(new KeyValuePair<string, string>("count", count.ToString()));
        }
        #endregion

        #region Internal Async Methods
        internal async Task<CategoriesRootObject> SelectCategoriesAsync()
        {
            CategoriesRootObject categoriesResponse = null;

            string url = string.Concat(apiRequestUrl, CommonAction.SelectCategories);
            var webRequest = new NTEC.Net.WebRequest(url)
            {
                Headers = new List<KeyValuePair<string, string>> { UserKey }
            };

            var response = await webRequest.GetAsync();

            if (!string.IsNullOrEmpty(response))
                categoriesResponse = JsonConvert.DeserializeObject<CategoriesRootObject>(response);

            return categoriesResponse;
        }

        internal async Task<CitiesRootObject> SelectCitiesAsync(string queryText, double? latitude, double? longitude, int[] cityIDs, int? count)
        {
            CitiesRootObject citiesResponse = null;

            var parameters = new List<KeyValuePair<string, string>>();

            AppendBaseParameters(ref parameters, null, latitude, longitude, count);

            if (!string.IsNullOrEmpty(queryText))
                parameters.Add(new KeyValuePair<string, string>("q", queryText));

            if (cityIDs?.Length > 0)
                parameters.Add(new KeyValuePair<string, string>("city_ids", string.Join(",", cityIDs)));

            string url = string.Concat(apiRequestUrl, CommonAction.SelectCities);
            var webRequest = new NTEC.Net.WebRequest(url)
            {
                Headers = new List<KeyValuePair<string, string>> { UserKey }
            };

            var response = await webRequest.GetAsync(parameters);

            if (!string.IsNullOrEmpty(response))
                citiesResponse = JsonConvert.DeserializeObject<CitiesRootObject>(response);

            return citiesResponse;
        }

        internal async Task<CollectionsRootObject> SelectCollectionsAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            CollectionsRootObject collectionsResponse = null;

            var parameters = new List<KeyValuePair<string, string>>();

            AppendBaseParameters(ref parameters, cityID, latitude, longitude, count);

            string url = string.Concat(apiRequestUrl, CommonAction.SelectCollections);
            var webRequest = new NTEC.Net.WebRequest(url)
            {
                Headers = new List<KeyValuePair<string, string>> { UserKey }
            };

            var response = await webRequest.GetAsync(parameters);

            if (!string.IsNullOrEmpty(response))
                collectionsResponse = JsonConvert.DeserializeObject<CollectionsRootObject>(response);

            return collectionsResponse;
        }

        internal async Task<CuisinesRootObject> SelectCuisinesAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            CuisinesRootObject cuisinesRootObject = null;

            var parameters = new List<KeyValuePair<string, string>>();

            AppendBaseParameters(ref parameters, cityID, latitude, longitude, count);

            string url = string.Concat(apiRequestUrl, CommonAction.SelectCuisines);
            var webRequest = new NTEC.Net.WebRequest(url)
            {
                Headers = new List<KeyValuePair<string, string>> { UserKey }
            };

            var response = await webRequest.GetAsync(parameters);

            if (!string.IsNullOrEmpty(response))
                cuisinesRootObject = JsonConvert.DeserializeObject<CuisinesRootObject>(response);

            return cuisinesRootObject;
        }

        internal async Task<EstablishmentsRootObject> SelectEstablishmentsAsync(int? cityID, double? latitude, double? longitude)
        {
            EstablishmentsRootObject establishmentsRootObject = null;

            var parameters = new List<KeyValuePair<string, string>>();

            AppendBaseParameters(ref parameters, cityID, latitude, longitude, null);

            string url = string.Concat(apiRequestUrl, CommonAction.SelectEstablishments);
            var webRequest = new NTEC.Net.WebRequest(url)
            {
                Headers = new List<KeyValuePair<string, string>> { UserKey }
            };

            var response = await webRequest.GetAsync(parameters);

            if (!string.IsNullOrEmpty(response))
                establishmentsRootObject = JsonConvert.DeserializeObject<EstablishmentsRootObject>(response);

            return establishmentsRootObject;
        }

        internal async Task<ZomatoRestaurant> GetRestaurantAsync(int restaurantID)
        {
            ZomatoRestaurant restaurantRootObject = null;

            var parameters = new List<KeyValuePair<string, string>>();

            parameters.Add(new KeyValuePair<string, string>("res_id", restaurantID.ToString()));

            string url = string.Concat(apiRequestUrl, RestaurantAction.Get);
            var webRequest = new NTEC.Net.WebRequest(url)
            {
                Headers = new List<KeyValuePair<string, string>> { UserKey }
            };

            var response = await webRequest.GetAsync(parameters);

            if (!string.IsNullOrEmpty(response))
                restaurantRootObject = JsonConvert.DeserializeObject<ZomatoRestaurant>(response);

            return restaurantRootObject;
        }

        internal async Task<DailyMenuRootObject> GetDailyMenuAsync(int restaurantID)
        {
            DailyMenuRootObject dailyMenuRootObject = null;

            var parameters = new List<KeyValuePair<string, string>>();

            parameters.Add(new KeyValuePair<string, string>("res_id", restaurantID.ToString()));

            string url = string.Concat(apiRequestUrl, RestaurantAction.GetDailyMenu);
            var webRequest = new NTEC.Net.WebRequest(url)
            {
                Headers = new List<KeyValuePair<string, string>> { UserKey }
            };

            var response = await webRequest.GetAsync(parameters);

            if (!string.IsNullOrEmpty(response))
                dailyMenuRootObject = JsonConvert.DeserializeObject<DailyMenuRootObject>(response);

            return dailyMenuRootObject;
        }

        internal async Task<GeocodeRootObject> SelectGeocodeAsync(double? latitude, double? longitude)
        {
            GeocodeRootObject geocodeRootObject = null;

            var parameters = new List<KeyValuePair<string, string>>();

            AppendBaseParameters(ref parameters, null, latitude, longitude, null);

            string url = string.Concat(apiRequestUrl, CommonAction.SelectGeocode);
            var webRequest = new NTEC.Net.WebRequest(url)
            {
                Headers = new List<KeyValuePair<string, string>> { UserKey }
            };

            var response = await webRequest.GetAsync(parameters);

            if (!string.IsNullOrEmpty(response))
                geocodeRootObject = JsonConvert.DeserializeObject<GeocodeRootObject>(response);

            return geocodeRootObject;
        }

        internal async Task<LocationDetailsRootObject> SelectLocationDetails(int? locationID, string entityType)
        {
            LocationDetailsRootObject locationDetailsRootObject = null;

            if (!locationID.HasValue || string.IsNullOrEmpty(entityType))
                throw new Exception("You need to specify both the location ID and entity type.");

            var parameters = new List<KeyValuePair<string, string>>();

            parameters.AddRange(new List<KeyValuePair<string, string>> {
                        new KeyValuePair<string, string>("entity_id", locationID.Value.ToString()),
                        new KeyValuePair<string, string>("entity_type", entityType)
                });

            string url = string.Concat(apiRequestUrl, LocationActions.GetDetails);
            var webRequest = new NTEC.Net.WebRequest(url)
            {
                Headers = new List<KeyValuePair<string, string>> { UserKey }
            };

            string response = await webRequest.GetAsync(parameters);

            if (!string.IsNullOrEmpty(response))
                locationDetailsRootObject = JsonConvert.DeserializeObject<LocationDetailsRootObject>(response);

            return locationDetailsRootObject;
        }

        internal async Task<LocationRootObject> SearchLocationAsync(string queryText, double? latitude, double? longitude, int? count)
        {
            LocationRootObject locations = null;

            if (string.IsNullOrEmpty(queryText))
                throw new Exception("You need to specify the search text.");

            var parameters = new List<KeyValuePair<string, string>>();

            parameters.Add(new KeyValuePair<string, string>("q", queryText));

            AppendBaseParameters(ref parameters, null, latitude, longitude, count);

            string url = string.Concat(apiRequestUrl, LocationActions.Search);
            var webRequest = new NTEC.Net.WebRequest(url)
            {
                Headers = new List<KeyValuePair<string, string>> { UserKey }
            };

            var response = await webRequest.GetAsync(parameters);

            if (!string.IsNullOrEmpty(response))
                locations = JsonConvert.DeserializeObject<LocationRootObject>(response);

            return locations;
        }

        internal async Task<ReviewsRootObject> SelectReviews(int? restaurantID, int? start, int? count)
        {
            ReviewsRootObject reviews = null;

            if (!restaurantID.HasValue)
                throw new Exception("You must specify a Restaurant ID.");

            var parameters = new List<KeyValuePair<string, string>>();

            parameters.Add(new KeyValuePair<string, string>("res_id", restaurantID.ToString()));

            if (start.HasValue)
                parameters.Add(new KeyValuePair<string, string>("start", start.ToString()));

            if (count.HasValue)
                parameters.Add(new KeyValuePair<string, string>("count", start.ToString()));

            string url = string.Concat(apiRequestUrl, RestaurantAction.SelectReviews);
            var webRequest = new NTEC.Net.WebRequest(url)
            {
                Headers = new List<KeyValuePair<string, string>> { UserKey }
            };

            var response = await webRequest.GetAsync(parameters);

            if (!string.IsNullOrEmpty(response))
                reviews = JsonConvert.DeserializeObject<ReviewsRootObject>(response);

            return reviews;
        }

        internal async Task<SearchRootObject> Search(int? entityID, string entityType, string queryText, int? start, int? count, double? latitude, double? longitude, double? radius, string cuisines, string establishmentType, string collectionID, string category, string sort, string order)
        {
            if (radius.HasValue && (!latitude.HasValue || !longitude.HasValue))
                throw new Exception("You need to specify both the latitude and longitude when requesting the radius.");

            SearchRootObject search = null;

            var parameters = new List<KeyValuePair<string, string>>();

            if (entityID.HasValue)
                parameters.Add(new KeyValuePair<string, string>("entity_id", entityID.Value.ToString()));

            if (!string.IsNullOrEmpty(entityType))
                parameters.Add(new KeyValuePair<string, string>("entity_type", entityType));

            if (!string.IsNullOrEmpty(queryText))
                parameters.Add(new KeyValuePair<string, string>("q", queryText));

            if (start.HasValue)
                parameters.Add(new KeyValuePair<string, string>("start", start.Value.ToString()));

            if (radius.HasValue)
                parameters.Add(new KeyValuePair<string, string>("radius", radius.Value.ToString()));

            if (!string.IsNullOrEmpty(cuisines))
                parameters.Add(new KeyValuePair<string, string>("cuisines", cuisines));

            if (!string.IsNullOrEmpty(establishmentType))
                parameters.Add(new KeyValuePair<string, string>("establishment_type", establishmentType));

            if (!string.IsNullOrEmpty(collectionID))
                parameters.Add(new KeyValuePair<string, string>("collection_id", collectionID));

            if (!string.IsNullOrEmpty(sort))
                parameters.Add(new KeyValuePair<string, string>("sort", sort));

            if (!string.IsNullOrEmpty(order))
                parameters.Add(new KeyValuePair<string, string>("order", order));

            AppendBaseParameters(ref parameters, null, latitude, longitude, count);

            string url = string.Concat(apiRequestUrl, RestaurantAction.Search);
            var webRequest = new NTEC.Net.WebRequest(url)
            {
                Headers = new List<KeyValuePair<string, string>> { UserKey }
            };

            var response = await webRequest.GetAsync(parameters);

            if (!string.IsNullOrEmpty(response))
                search = JsonConvert.DeserializeObject<SearchRootObject>(response);

            return search;
        }
        #endregion
    }
}