using System.Threading.Tasks;
using Zomato.API.Domain;

namespace Zomato.API
{
    public sealed partial class ZomatoService
    {
        #region Public Async Methods
        /// <summary>
        /// Get Foodie Index, Nightlife Index, Top Cuisines and Best rated restaurants in a given location.
        /// </summary>
        /// <param name="locationID">ID of the location.</param>
        /// <param name="entityType">Name of the entity.</param>
        /// <returns>A list of popular cuisines and nearby restaurants around the given location.</returns>
        public async Task<LocationDetails> SelectLocationDetailsAsync(int? locationID, string entityType)
        {
            LocationDetails locationDetails = null;
            LocationDetailsRootObject locationDetailsResponse = null;

            locationDetailsResponse = await webRequest.SelectLocationDetails(locationID, entityType);

            if (locationDetailsResponse == null)
                return locationDetails;

            locationDetails = locationDetailsResponse.ToServiceObject();

            return locationDetails;
        }
        #endregion

        /// <summary>
        /// Search for Zomato locations by keyword. Provide coordinates to get better search results.
        /// </summary>
        /// <param name="queryText">The text to search for.</param>
        /// <returns>A list of locations.</returns>
        public async Task<Locations> SearchLocationAsync(string queryText, int? count = null)
        {
            return await SearchLocationAsync(queryText, null, null, count);
        }
        /// <summary>
        /// Search for Zomato locations by keyword. Provide coordinates to get better search results.
        /// </summary>
        /// <param name="queryText">The text to search for.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of locations.</returns>
        public async Task<Locations> SearchLocationAsync(string queryText, double? latitude, double? longitude, int? count = null)
        {
            Locations locations = null;
            LocationRootObject zomatoLocations = null;

            zomatoLocations = await webRequest.SearchLocationAsync(queryText, latitude, longitude, count);

            if (zomatoLocations == null)
                return locations;

            locations = zomatoLocations.ToServiceObject();

            return locations;
        }
    }
}