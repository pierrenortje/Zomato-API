using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zomato.API.Controllers;
using Zomato.API.Domain;
using Zomato.API.Util;

namespace Zomato.API
{
    internal sealed class WebRequest : IDisposable
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

        #region Internal Async Methods
        internal async Task<CategoriesRootObject> SelectCategories()
        {
            CategoriesRootObject categoriesResponse = null;

            var response = await webRequest.Get(CommonAction.SelectCategories);

            if (!string.IsNullOrEmpty(response))
                categoriesResponse = JsonConvert.DeserializeObject<CategoriesRootObject>(response);

            return categoriesResponse;
        }

        internal async Task<CitiesRootObject> SelectCities(string queryText)
        {
            CitiesRootObject citiesResponse = null;

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("q", queryText)
            };

            var response = await webRequest.Get(CommonAction.SelectCities, parameters);

            if (!string.IsNullOrEmpty(response))
                citiesResponse = JsonConvert.DeserializeObject<CitiesRootObject>(response);

            return citiesResponse;
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            if (webRequest != null)
            {
                webRequest = null;
            }
        }
        #endregion
    }
}
