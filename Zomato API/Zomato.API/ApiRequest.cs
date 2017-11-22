using RestSharp;
using System;
using Zomato.API.Requests;

namespace Zomato.API
{
    public class ApiRequest
    {
        #region Private Fields
        private readonly IRestClient client;
        private readonly string apiKey;
        #endregion

        #region Constructor
        public ApiRequest(string apiKey)
        {
            this.apiKey = apiKey;

            this.client = new RestClient
            {
                BaseUrl = new Uri("https://developers.zomato.com/api/v2.1/")
            };
        }
        #endregion

        #region Public Properties
        public CommonRequest CommonRequest { get { return new CommonRequest(this.client, this.apiKey); } }
        public LocationRequest LocationRequest { get { return new LocationRequest(this.client, this.apiKey); } }
        public RestaurantRequest RestaurantRequest { get { return new RestaurantRequest(this.client, this.apiKey); } }
        #endregion
    }
}
