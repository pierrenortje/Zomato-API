using System;
using System.Threading.Tasks;
using Zomato.API.Domain;

namespace Zomato.API
{
    public sealed class ZomatoService : IDisposable
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
        /// <returns>A list of categories.</returns>
        public async Task<Cities> SelectCities(string queryText)
        {
            Cities cities = null;
            CitiesRootObject citiesResponse = null;

            citiesResponse = await webRequest.SelectCities(queryText);

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
        /// Get a list of restaurants in a city
        /// </summary> 
        /// <returns>A list of collections of restaurants</returns>
        public async Task<Collections> SelectCollections(int queryText)
        {
            Collections collections = null;
            CollectionRootObject collectionResponse = null;

            collectionResponse = await webRequest.SelectCollections(queryText);

            if(collectionResponse?.Restaurants == null) {
                return collections;
            }

            collections = new Collections();

            foreach(var restaurant in collectionResponse.Restaurants) {
                var entry = restaurant.Restaurant;

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

        #region IDisposable Members
        public void Dispose()
        {
            if (webRequest != null)
            {
                webRequest = null;
            }
        }
        #endregion
    }
}