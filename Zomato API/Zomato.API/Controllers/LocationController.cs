namespace Zomato.API.Controllers
{
    internal sealed class LocationController : BaseController { }

    internal sealed class LocationActions
    {
        #region Actions
        /// <summary>
        /// Get Foodie Index, Nightlife Index, Top Cuisines and Best rated restaurants in a given location.
        /// </summary>
        internal const string GetDetails = "location_details";

        /// <summary>
        /// Search for Zomato locations by keyword. Provide coordinates to get better search results.
        /// </summary>
        internal const string Search = "locations";
        #endregion
    }
}