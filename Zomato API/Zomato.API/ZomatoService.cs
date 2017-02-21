using System;
using System.Linq;
using System.Threading.Tasks;
using Zomato.API.Domain;

namespace Zomato.API
{
    public sealed class ZomatoService
    {
        #region Private Fields
        private WebRequest webRequest = null;
        #endregion

        #region Constructor
        public ZomatoService()
        {
            webRequest = new WebRequest();
        }
        #endregion

        #region Public Async Methods
        /// <summary>
        /// Select a list of categories.
        /// </summary>
        /// <returns>A list of categories.</returns>
        public async Task<Categories> SelectCategories()
        {
            Categories categories = null;
            CategoriesRootObject categoriesResponse = null;

            categoriesResponse = await webRequest.SelectCategories();

            if (categoriesResponse?.Categories == null)
                return categories;

            categories = new Categories();

            foreach (var category in categoriesResponse.Categories)
                categories.Add(new Category
                {
                    ID = category.Categories.ID,
                    Name = category.Categories.Name
                });

            return categories;
        }

        /// <summary>
        /// Select a list of cities.
        /// </summary>
        /// <param name="queryText">The query text to search for.</param>
        /// <returns>A list of categories.</returns>
        public async Task<Cities> SelectCities(string queryText, int? count = null)
        {
            return await SelectCities(queryText, null, null, null, count);
        }
        /// <summary>
        /// Select a list of cities.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns>A list of categories.</returns>
        public async Task<Cities> SelectCities(double latitude, double longitude, int? count = null)
        {
            return await SelectCities(null, latitude, longitude, null, count);
        }
        /// <summary>
        /// Select a list of cities.
        /// </summary>
        /// <param name="cityIDs">A list of city IDs.</param>
        /// <returns>A list of categories.</returns>
        public async Task<Cities> SelectCities(int[] cityIDs, int? count = null)
        {
            return await SelectCities(null, null, null, cityIDs, count);
        }
        #endregion

        #region Private Async Methods
        /// <summary>
        /// Select a list of cities.
        /// </summary>
        /// <returns>A list of categories.</returns>
        private async Task<Cities> SelectCities(string queryText, double? latitude, double? longitude, int[] cityIDs, int? count)
        {
            Cities cities = null;
            CitiesRootObject citiesResponse = null;

            citiesResponse = await webRequest.SelectCities(queryText, latitude, longitude, cityIDs, count);

            if (citiesResponse?.Locations == null)
                return cities;

            cities = new Cities();

            foreach (var city in citiesResponse.Locations)
            {
                var country = new Country
                {
                    ID = city.CountryID,
                    Name = city.CountryName
                };
                cities.Add(new City
                {
                    ID = city.ID,
                    Name = city.Name,
                    Country = country
                });
            }

            return cities;
        }
        #endregion
    }
}