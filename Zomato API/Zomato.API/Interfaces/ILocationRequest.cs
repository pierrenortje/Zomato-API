using System.Threading.Tasks;
using Zomato.API.Models;

namespace Zomato.API.Interfaces
{
    public interface ILocationRequest
    {
        /// <summary>
        /// Get Foodie Index, Nightlife Index, Top Cuisines and Best rated restaurants in a given location.
        /// </summary>
        /// <param name="locationID">ID of the location.</param>
        /// <param name="entityType">Name of the entity.</param>
        /// <returns>A list of popular cuisines and nearby restaurants around the given location.</returns>
        Task<LocationDetailsData> SelectLocationDetails(int locationID, string entityType);

        /// <summary>
        /// Search for Zomato locations by keyword. Provide coordinates to get better search results.
        /// </summary>
        /// <param name="queryText">The text to search for.</param>
        /// <returns>A list of locations.</returns>
        Task<LocationData> SearchLocation(string queryText, int? count = null);
        /// <summary>
        /// Search for Zomato locations by keyword. Provide coordinates to get better search results.
        /// </summary>
        /// <param name="queryText">The text to search for.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of locations.</returns>
        Task<LocationData> SearchLocation(string queryText, double? latitude, double? longitude, int? count = null);
    }
}
