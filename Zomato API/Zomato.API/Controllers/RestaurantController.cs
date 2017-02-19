namespace Zomato.API.Controllers
{
    internal sealed class RestaurantController : BaseController { }

    internal sealed class RestaurantAction
    {
        #region Actions
        /// <summary>
        /// Get daily menu using Zomato restaurant ID.
        /// </summary>
        internal const string GetDailyMenu = "dailymenu";

        /// <summary>
        /// Get detailed restaurant information using Zomato restaurant ID. Partner Access is required to access photos and reviews.
        /// </summary>
        internal const string Get = "restaurant";

        /// <summary>
        /// Get restaurant reviews using the Zomato restaurant ID.
        /// </summary>
        internal const string SelectReviews = "reviews";

        /// <summary>
        /// The location input can be specified using Zomato location ID or coordinates.
        /// Cuisine / Establishment / Collection IDs can be obtained from respective api calls.
        /// Partner Access is required to access photos and reviews.
        /// </summary>
        internal const string Search = "search";
        #endregion
    }
}