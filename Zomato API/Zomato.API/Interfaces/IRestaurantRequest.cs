using System.Threading.Tasks;
using Zomato.API.Models;

namespace Zomato.API.Interfaces
{
    public interface IRestaurantRequest
    {
        /// <summary>
        /// Get daily menu of a restaurant.
        /// </summary>
        /// <param name="restaurantId">The restaurant's ID.</param>
        /// <returns>The daily menu.</returns>
        Task<DailyMenuData> GetDailyMenu(int restaurantId);

        /// <summary>
        /// Get restaurant details. Partner Access is required to access photos and reviews.
        /// </summary>
        /// <param name="restaurantId">The restaurant's ID.</param>
        /// <returns>A restaurant.</returns>
        Task<Restaurant> GetRestaurant(int restaurantId);

        /// <summary>
        /// Select restaurant reviews.
        /// </summary>
        /// <param name="restaurantId">Restaurant's ID.</param>
        /// <param name="start">The offset to fetch results from.</param>
        /// <param name="count">Amount of results to return.</param>
        /// <returns>A list of reviews.</returns>
        Task<ReviewsData> SelectReviews(int restaurantId, int? start, int? count = null);

        /// <summary>
        /// Search for restaurants.
        /// </summary>
        /// <param name="categoryIDs">An array of category IDs.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="start">The offset to fetch results from.</param>
        /// <param name="count">Amount of results to return.</param>
        /// <param name="sort">The sort order.</param>
        /// <param name="order">The order in which to sort.</param>
        /// <returns>A list of restaurants.</returns>
        Task<SearchData> Search(int? locationID = null, string locationType = null, string queryText = null, int? start = null, int? count = null, double? longitude = null, double? latitude = null, double? radius = null, string cuisines = null, string establishmentId = null, string collectionId = null, string[] categoryIDs = null, string sort = null, string order = null);
    }
}
