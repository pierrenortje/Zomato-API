using Newtonsoft.Json;
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
        private NTEC.Net.WebRequest webRequest = null;
        private string apiKey = ConfigurationHelper.GetApiKey();
        #endregion

        #region Private Const Fields
        private const string apiRequestUrl = "https://developers.zomato.com/api/v2.1/";
        private const string userKeyHeaderKey = "user-key";
        #endregion

        #region Constructor
        internal WebRequest()
        {
            webRequest = new NTEC.Net.WebRequest(apiRequestUrl)
            {
                Headers = new List<KeyValuePair<string, string>> { UserKey }
            };
        }
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

            var response = await webRequest.Get(CommonAction.SelectCategories);

            if (!string.IsNullOrEmpty(response))
                categoriesResponse = JsonConvert.DeserializeObject<CategoriesRootObject>(response);

            return categoriesResponse;
        }

        internal async Task<CitiesRootObject> SelectCitiesAsync(string queryText, double? latitude, double? longitude, int[] cityIDs, int? count)
        {
            if ((!latitude.HasValue && longitude.HasValue) || (latitude.HasValue && !longitude.HasValue))
                throw new Exception("You need to specify both the latitude and longitude.");

            CitiesRootObject citiesResponse = null;

            var parameters = new List<KeyValuePair<string, string>>();

            AppendBaseParameters(ref parameters, null, latitude, longitude, count);

            if (!string.IsNullOrEmpty(queryText))
                parameters.Add(new KeyValuePair<string, string>("q", queryText));

            if (cityIDs?.Length > 0)
                parameters.Add(new KeyValuePair<string, string>("city_ids", string.Join(",", cityIDs)));

            var response = await webRequest.Get(CommonAction.SelectCities, parameters);

            if (!string.IsNullOrEmpty(response))
                citiesResponse = JsonConvert.DeserializeObject<CitiesRootObject>(response);

            return citiesResponse;
        }

        internal async Task<CollectionsRootObject> SelectCollectionsAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            CollectionsRootObject collectionsResponse = null;

            if ((!latitude.HasValue && longitude.HasValue) || (latitude.HasValue && !longitude.HasValue))
                throw new Exception("You need to specify both the latitude and longitude.");

            var parameters = new List<KeyValuePair<string, string>>();

            AppendBaseParameters(ref parameters, cityID, latitude, longitude, count);

            var response = await webRequest.Get(CommonAction.SelectCollections, parameters);

            if (!string.IsNullOrEmpty(response))
                collectionsResponse = JsonConvert.DeserializeObject<CollectionsRootObject>(response);

            return collectionsResponse;
        }

        internal async Task<CuisinesRootObject> SelectCuisinesAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            CuisinesRootObject cuisinesRootObject = null;

            if ((!latitude.HasValue && longitude.HasValue) || (latitude.HasValue && !longitude.HasValue))
                throw new Exception("You need to specify both the latitude and longitude.");

            var parameters = new List<KeyValuePair<string, string>>();

            AppendBaseParameters(ref parameters, cityID, latitude, longitude, count);

            var response = await webRequest.Get(CommonAction.SelectCuisines, parameters);

            if (!string.IsNullOrEmpty(response))
                cuisinesRootObject = JsonConvert.DeserializeObject<CuisinesRootObject>(response);

            return cuisinesRootObject;
        }
        #endregion
    }
}