using RestSharp;
using System.Threading.Tasks;
using Zomato.API.Interfaces;
using Zomato.API.Models;

namespace Zomato.API.Requests
{
    public class CommonRequest : RequestBase, ICommonRequest
    {
        public CommonRequest(IRestClient restClient, string apiKey) : base(restClient, apiKey) { }

        #region Categories
        public async Task<CategoriesData> SelectCategories()
        {
            var request = new RestRequest("categories", Method.GET);

            return await base.ExecuteGet<CategoriesData>(request);
        }
        #endregion

        #region Cities
        public async Task<CitiesData> SelectCities(int[] cityIDs, int? count = default(int?))
        {
            var request = new RestRequest("cities", Method.GET);
            request.AddParameter("city_ids", string.Join(",", cityIDs));

            base.Count = count;

            return await base.ExecuteGet<CitiesData>(request);
        }
        public async Task<CitiesData> SelectCities(string queryText, int? count = default(int?))
        {
            var request = new RestRequest("cities", Method.GET);
            request.AddParameter("q", queryText);

            base.Count = count;

            return await base.ExecuteGet<CitiesData>(request);
        }
        public async Task<CitiesData> SelectCities(double latitude, double longitude, int? count = default(int?))
        {
            var request = new RestRequest("cities", Method.GET);

            base.Count = count;
            base.Latitude = latitude;
            base.Longitude = longitude;

            return await base.ExecuteGet<CitiesData>(request);
        }
        #endregion

        #region Collections
        public async Task<CollectionsData> SelectCollections(int cityID, int? count = default(int?))
        {
            var request = new RestRequest("collections", Method.GET);
            request.AddParameter("city_id", cityID);

            base.Count = count;

            return await base.ExecuteGet<CollectionsData>(request);
        }
        public async Task<CollectionsData> SelectCollections(double latitude, double longitude, int? count = default(int?))
        {
            var request = new RestRequest("collections", Method.GET);

            base.Count = count;
            base.Latitude = latitude;
            base.Longitude = longitude;

            return await base.ExecuteGet<CollectionsData>(request);
        }
        #endregion

        #region Cuisines
        public async Task<CuisinesData> SelectCuisines(int cityID, int? count = default(int?))
        {
            var request = new RestRequest("cuisines", Method.GET);
            request.AddParameter("city_id", cityID);

            base.Count = count;

            return await base.ExecuteGet<CuisinesData>(request);
        }
        public async Task<CuisinesData> SelectCuisines(double latitude, double longitude, int? count = default(int?))
        {
            var request = new RestRequest("cuisines", Method.GET);

            base.Count = count;
            base.Latitude = latitude;
            base.Longitude = longitude;

            return await base.ExecuteGet<CuisinesData>(request);
        }
        #endregion

        #region Establishments
        public async Task<EstablishmentsData> SelectEstablishments(int cityID)
        {
            var request = new RestRequest("establishments", Method.GET);
            request.AddParameter("city_id", cityID);

            return await base.ExecuteGet<EstablishmentsData>(request);
        }
        public async Task<EstablishmentsData> SelectEstablishments(double latitude, double longitude)
        {
            var request = new RestRequest("establishments", Method.GET);

            base.Latitude = latitude;
            base.Longitude = longitude;

            return await base.ExecuteGet<EstablishmentsData>(request);
        }
        #endregion

        #region Geocode
        public async Task<GeocodeData> SelectGeocode(double latitude, double longitude)
        {
            var request = new RestRequest("geocode", Method.GET);

            base.Latitude = latitude;
            base.Longitude = longitude;

            return await base.ExecuteGet<GeocodeData>(request);
        }
        #endregion
    }
}
