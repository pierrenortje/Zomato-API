namespace Zomato.API.Controllers
{
    internal sealed class CommonController : BaseController { }

    internal sealed class CommonAction
    {
        #region Actions
        /// <summary>
        /// Get a list of categories. List of all restaurants categorized under a particular
        /// restaurant type can be obtained using /Search API with Category ID as inputs.
        /// </summary>
        internal const string SelectCategories = "categories";

        /// <summary>
        /// Find the Zomato ID and other details for a city .
        /// </summary>
        internal const string SelectCities = "cities";

        /// <summary>
        /// Returns Zomato Restaurant Collections in a City.
        /// </summary>
        internal const string SelectCollections = "collections";

        /// <summary>
        /// Get a list of all cuisines of restaurants listed in a city.
        /// </summary>
        internal const string SelectCuisines = "cuisines";

        /// <summary>
        /// Get a list of restaurant types in a city.
        /// </summary>
        internal const string SelectEstablishments = "establishments";

        /// <summary>
        /// Get Foodie and Nightlife Index, list of popular cuisines and nearby restaurants around the given coordinates.
        /// </summary>
        internal const string SelectGeocode = "geocode";
        #endregion
    }
}