using System.Threading.Tasks;
using Zomato.API.Models;

namespace Zomato.API.Interfaces
{
    public interface ICommonRequest
    {
        /// <summary>
        /// Select a list of categories.
        /// </summary>
        /// <returns>A list of categories.</returns>
        Task<CategoriesData> SelectCategories();

        /// <summary>
        /// Select a list of cities.
        /// </summary>
        /// <param name="queryText">The query text to search for.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of categories.</returns>
        Task<CitiesData> SelectCities(string queryText, int? count = null);
        /// <summary>
        /// Select a list of cities.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of categories.</returns>
        Task<CitiesData> SelectCities(double latitude, double longitude, int? count = null);
        /// <summary>
        /// Select a list of cities.
        /// </summary>
        /// <param name="cityIDs">A list of city IDs.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of categories.</returns>
        Task<CitiesData> SelectCities(int[] cityIDs, int? count = null);

        /// <summary>
        /// Select a collection of restaurants in a city.
        /// </summary>
        /// <param name="cityID">The city's ID.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of collections.</returns>
        Task<CollectionsData> SelectCollections(int cityID, int? count = null);
        /// <summary>
        /// Select a collection of restaurants by latitude and longitude.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of collections.</returns>
        Task<CollectionsData> SelectCollections(double latitude, double longitude, int? count = null);

        /// <summary>
        /// Select a list of cuisines in a city.
        /// </summary>
        /// <param name="cityID">The city's ID.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of cuisines.</returns>
        Task<CuisinesData> SelectCuisines(int cityID, int? count = null);
        /// <summary>
        /// Select a list of cuisines by latitude and longitude.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of cuisines.</returns>
        Task<CuisinesData> SelectCuisines(double latitude, double longitude, int? count = null);

        /// <summary>
        /// Select a list of establishments in a city.
        /// </summary>
        /// <param name="cityID">The city's ID.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of establishments.</returns>
        Task<EstablishmentsData> SelectEstablishments(int cityID);
        /// <summary>
        /// Select a list of establishments by latitude and longitude.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of establishments.</returns>
        Task<EstablishmentsData> SelectEstablishments(double latitude, double longitude);

        /// <summary>
        /// Get a food & nightlife index by latitude and longitude.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns>A list of popular cuisines and nearby restaurants around the given coordinates.</returns>
        Task<GeocodeData> SelectGeocode(double latitude, double longitude);
    }
}
