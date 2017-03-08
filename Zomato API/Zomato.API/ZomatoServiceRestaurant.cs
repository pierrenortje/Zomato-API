using System.Threading.Tasks;
using Zomato.API.Domain;

namespace Zomato.API
{
    public sealed partial class ZomatoService
    {
        #region Public Async Methods
        /// <summary>
        /// Get the daily menu by restaurant ID.
        /// </summary>
        /// <param name="restaurantID">The restaurant's ID.</param>
        /// <returns>The daily menu.</returns>
        public async Task<DailyMenus> GetDailyMenuAsync(int restaurantID)
        {
            DailyMenus dailyMenus = null;
            DailyMenuRootObject dailyMenuResponse = null;

            dailyMenuResponse = await webRequest.GetDailyMenuAsync(restaurantID);

            if (dailyMenuResponse == null)
                return dailyMenus;

            dailyMenus = dailyMenuResponse.ToServiceObject();

            return dailyMenus;
        }

        /// <summary>
        /// Get a restaurant by its ID. Partner Access is required to access photos and reviews.
        /// </summary>
        /// <param name="restaurantID">The restaurant's ID.</param>
        /// <returns>A restaurant.</returns>
        public async Task<Restaurant> GetRestaurantAsync(int restaurantID)
        {
            Restaurant restaurant = null;
            ZomatoRestaurant restaurantResponse = null;

            restaurantResponse = await webRequest.GetRestaurantAsync(restaurantID);

            if (restaurantResponse == null)
                return restaurant;

            restaurant = restaurantResponse.ToServiceObject();

            return restaurant;
        }

        /// <summary>
        /// Get the reviews of a restaurant by ID
        /// </summary>
        /// <param name="resID">Restaurant's ID</param>
        /// <param name="start">Index to start from. (not required)</param>
        /// <param name="count">Amount of reviews to display. (not required)</param>
        /// <returns></returns>
        public async Task<ReviewsEndpoint> GetReviewsAsync(int? resID, int? start, int? count)
        {
            ReviewsEndpoint reviewsEndpoint = null;
            ReviewsRootObject reviewsResponse = null;

            start = start.HasValue ? start : 0;
            count = count.HasValue ? count : 0;

            reviewsResponse = await webRequest.SelectReviews(resID, start, count);

            if(reviewsResponse == null)
                return reviewsEndpoint;

            reviewsEndpoint = reviewsResponse.ToServiceObject();

            return reviewsEndpoint;
        }
        #endregion
    }
}