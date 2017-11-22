using RestSharp;
using System.Threading.Tasks;
using Zomato.API.Interfaces;
using Zomato.API.Models;

namespace Zomato.API.Requests
{
    public class RestaurantRequest : RequestBase, IRestaurantRequest
    {
        public RestaurantRequest(IRestClient restClient, string apiKey) : base(restClient, apiKey) { }

        public async Task<DailyMenuData> GetDailyMenu(int restaurantId)
        {
            var request = new RestRequest("dailymenu", Method.GET);
            request.AddParameter("res_id", restaurantId);

            return await base.ExecuteGet<DailyMenuData>(request);
        }

        public async Task<Restaurant> GetRestaurant(int restaurantId)
        {
            var request = new RestRequest("restaurant", Method.GET);
            request.AddParameter("res_id", restaurantId);

            return await base.ExecuteGet<Restaurant>(request);
        }

        public async Task<SearchData> Search(int? locationID = default(int?), string locationType = null, string queryText = null, int? start = default(int?), int? count = default(int?), double? longitude = default(double?), double? latitude = default(double?), double? radius = default(double?), string cuisines = null, string establishmentId = null, string collectionId = null, string[] categoryIDs = null, string sort = null, string order = null)
        {
            var request = new RestRequest("restaurant", Method.GET);

            if (locationID.HasValue)
                request.AddParameter("entity_id", locationID);
            if (!string.IsNullOrEmpty(locationType))
                request.AddParameter("entity_type", locationType);

            if (!string.IsNullOrEmpty(queryText))
                request.AddParameter("q", queryText);

            if (start.HasValue)
                request.AddParameter("start", start.Value);

            if (longitude.HasValue)
                request.AddParameter("lon", longitude.Value);
            if (latitude.HasValue)
                request.AddParameter("lat", latitude.Value);
            if (radius.HasValue)
                request.AddParameter("radius", radius.Value);

            if (!string.IsNullOrEmpty(cuisines))
                request.AddParameter("cuisines", cuisines);

            if (!string.IsNullOrEmpty(establishmentId))
                request.AddParameter("establishment_type", establishmentId);

            if (!string.IsNullOrEmpty(collectionId))
                request.AddParameter("collection_id", collectionId);

            if (categoryIDs != null)
                request.AddParameter("category", string.Join(",", categoryIDs));

            if (!string.IsNullOrEmpty(sort))
                request.AddParameter("sort", sort);

            if (!string.IsNullOrEmpty(order))
                request.AddParameter("order", order);

            base.Count = count;

            return await base.ExecuteGet<SearchData>(request);
        }

        public async Task<ReviewsData> SelectReviews(int restaurantId, int? start, int? count = default(int?))
        {
            var request = new RestRequest("restaurant", Method.GET);
            request.AddParameter("res_id", restaurantId);

            if (start.HasValue)
                request.AddParameter("start", start.Value);

            base.Count = count;

            return await base.ExecuteGet<ReviewsData>(request);
        }
    }
}
