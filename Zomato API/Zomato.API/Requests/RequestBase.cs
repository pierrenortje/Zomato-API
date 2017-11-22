using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace Zomato.API.Requests
{
    public class RequestBase
    {
        #region Protected Fields
        protected readonly IRestClient restClient;
        protected readonly string apiKey;
        #endregion

        #region Constructor
        public RequestBase(IRestClient restClient, string apiKey)
        {
            this.restClient = restClient;
            this.apiKey = apiKey;
        }
        #endregion

        #region Public Properties
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }

        public int? Count { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        #endregion

        #region Protected Methods
        protected async Task<TResponseType> ExecuteGet<TResponseType>(IRestRequest request)
        {
            if (Count.HasValue)
                request.AddParameter("count", Count.Value);

            if (Latitude.HasValue)
                request.AddParameter("lat", Latitude.Value);
            if (Longitude.HasValue)
                request.AddParameter("lon", Longitude.Value);

            request.AddHeader("user-key", this.apiKey);

            var response = await restClient.ExecuteTaskAsync<TResponseType>(request);

            StatusDescription = response.StatusDescription;
            StatusCode = response.StatusCode;

            return response.Data;
        }
        #endregion
    }
}
