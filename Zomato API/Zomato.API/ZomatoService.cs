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

        /// <summary>
        /// Select a list of restaurants in a city
        /// </summary>
        /// <param name="queryText">City ID</param>
        /// <param name="count">Amount of results</param>
        /// <returns></returns>
        public async Task<Collections> SelectCollections(int queryText, int? count = null)
        {
            return await SelectCollections(queryText, null, null, count);
        }

        /// <summary>
        /// Select a list of restaurants in a city
        /// </summary>
        /// <param name="lat">The latitude</param>
        /// <param name="lon">The longitude</param>
        /// <param name="count">Amount of results</param>
        /// <returns></returns>
        public async Task<Collections> SelectCollections(double lat, double lon, int? count = null)
        {
            return await SelectCollections(null, lat, lon, count);
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

        /// <summary>
        /// Select a list of restaurants in a city
        /// </summary> 
        /// <returns>A list of collections of restaurants</returns>
        private async Task<Collections> SelectCollections(int? queryText, double? lat, double? lon, int? count)
        {
            Collections collections = null;
            CollectionRootObject collectionResponse = null;

            collectionResponse = await webRequest.SelectCollections(queryText, lat, lon, count);

            if(collectionResponse?.RestaurantCollection == null) {
                return collections;
            }

            collections = new Collections();

            foreach(var restaurants in collectionResponse.RestaurantCollection) {
                var entry = restaurants.Restaurants;

                collections.Add(new Collection{
                    ID = entry.Collection_id,
                    Title = entry.Title,
                    Url = entry.Url,
                    Description = entry.Description
                });
            }

            return collections;
        }
        #endregion
    }
}