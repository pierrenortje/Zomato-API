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
        /// Select the reviews of a restaurant.
        /// </summary>
        /// <param name="restaurantID">Restaurant's ID.</param>
        /// <returns>A list of reviews.</returns>
        public async Task<ReviewCollection> SelectReviewsAsync(int restaurantID)
        {
            return await SelectReviewsAsync(restaurantID, null, null);
        }
        /// <summary>
        /// Select the reviews of a restaurant.
        /// </summary>
        /// <param name="restaurantID">Restaurant's ID.</param>
        /// <param name="count">Amount of reviews to display.</param>
        /// <returns>A list of reviews.</returns>
        public async Task<ReviewCollection> SelectReviewsAsync(int restaurantID, int start)
        {
            return await SelectReviewsAsync(restaurantID, start, null);
        }
        /// <summary>
        /// Select the reviews of a restaurant.
        /// </summary>
        /// <param name="restaurantID">Restaurant's ID.</param>
        /// <param name="start">Index to start from.</param>
        /// <param name="count">Amount of reviews to display.</param>
        /// <returns>A list of reviews.</returns>
        public async Task<ReviewCollection> SelectReviewsAsync(int restaurantID, int? start, int? count = null)
        {
            ReviewCollection reviews = null;
            ReviewsRootObject reviewsResponse = null;

            reviewsResponse = await webRequest.SelectReviews(restaurantID, start, count);

            if (reviewsResponse == null)
                return reviews;

            reviews = reviewsResponse.ToServiceObject();

            return reviews;
        }
        #endregion
    }
}