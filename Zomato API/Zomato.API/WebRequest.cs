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
        #endregion

        #region Constructor
        internal WebRequest()
        {
            webRequest = new NTEC.Net.WebRequest(apiRequestUrl);
        }
        #endregion

        #region Internal Async Methods
        // TODO: Refactor this method.
        internal async Task<CategoriesResponse> SelectCategories()
        {
            CategoriesResponse categoriesResponse = null;
            var businessController = new BusinessController();
            var postUrl = string.Concat(apiRequestUrl, BusinessActions.SelectCategories);
            var postHeaders = new List<KeyValuePair<string, string>>();
            postHeaders.Add(new KeyValuePair<string, string>("user-key", apiKey));

            // TODO: Fix POST not returning response.
            var response = await webRequest.Post(postUrl, null, postHeaders);

            if (!string.IsNullOrEmpty(response))
            {
                categoriesResponse = JsonConvert.DeserializeObject<CategoriesResponse>(response);
            }

            return categoriesResponse;
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
