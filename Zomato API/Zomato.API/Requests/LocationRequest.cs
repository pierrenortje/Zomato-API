using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.API.Interfaces;
using Zomato.API.Models;

namespace Zomato.API.Requests
{
    public class LocationRequest : RequestBase, ILocationRequest
    {
        public LocationRequest(IRestClient restClient, string apiKey) : base(restClient, apiKey) { }

        public async Task<LocationData> SearchLocation(string queryText, int? count = default(int?))
        {
            var request = new RestRequest("locations", Method.GET);
            request.AddParameter("q", queryText);

            base.Count = count;

            return await base.ExecuteGet<LocationData>(request);
        }
        public async Task<LocationData> SearchLocation(string queryText, double? latitude, double? longitude, int? count = default(int?))
        {
            var request = new RestRequest("locations", Method.GET);
            request.AddParameter("q", queryText);

            base.Count = count;
            base.Latitude = latitude;
            base.Longitude = longitude;

            return await base.ExecuteGet<LocationData>(request);
        }

        public async Task<LocationDetailsData> SelectLocationDetails(int locationID, string entityType)
        {
            var request = new RestRequest("location_details", Method.GET);

            request.AddParameter("entity_id", locationID);
            request.AddParameter("entity_type", entityType);

            return await base.ExecuteGet<LocationDetailsData>(request);
        }
    }
}
