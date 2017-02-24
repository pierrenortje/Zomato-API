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
        public async Task<Categories> SelectCategoriesAsync()
        {
            Categories categories = null;
            CategoriesRootObject categoriesResponse = null;

            categoriesResponse = await webRequest.SelectCategoriesAsync();

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
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of categories.</returns>
        public async Task<Cities> SelectCitiesAsync(string queryText, int? count = null)
        {
            return await SelectCitiesAsync(queryText, null, null, null, count);
        }
        /// <summary>
        /// Select a list of cities.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return</param>
        /// <returns>A list of categories.</returns>
        public async Task<Cities> SelectCitiesAsync(double latitude, double longitude, int? count = null)
        {
            return await SelectCitiesAsync(null, latitude, longitude, null, count);
        }
        /// <summary>
        /// Select a list of cities.
        /// </summary>
        /// <param name="cityIDs">A list of city IDs.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of categories.</returns>
        public async Task<Cities> SelectCitiesAsync(int[] cityIDs, int? count = null)
        {
            return await SelectCitiesAsync(null, null, null, cityIDs, count);
        }

        /// <summary>
        /// Select a collection of restaurants in a city.
        /// </summary>
        /// <param name="cityID">The city's ID.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of collections.</returns>
        public async Task<Collections> SelectCollectionsAsync(int cityID, int? count = null)
        {
            return await SelectCollectionsAsync(cityID, null, null, count);
        }
        /// <summary>
        /// Select a collection of restaurants by latitude and longitude.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of collections.</returns>
        public async Task<Collections> SelectCollectionsAsync(double latitude, double longitude, int? count = null)
        {
            return await SelectCollectionsAsync(null, latitude, longitude, count);
        }

        /// <summary>
        /// Select a list of cuisines in a city.
        /// </summary>
        /// <param name="cityID">The city's ID.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of cuisines.</returns>
        public async Task<Cuisines> SelectCuisinesAsync(int cityID, int? count = null)
        {
            return await SelectCuisinesAsync(cityID, null, null, count);
        }
        /// <summary>
        /// Select a list of cuisines by latitude and longitude.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of cuisines.</returns>
        public async Task<Cuisines> SelectCuisinesAsync(double latitude, double longitude, int? count = null)
        {
            return await SelectCuisinesAsync(null, latitude, longitude, count);
        }

        /// <summary>
        /// Select a list of establishments in a city.
        /// </summary>
        /// <param name="cityID">The city's ID.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of establishments.</returns>
        public async Task<Establishments> SelectEstablishmentsAsync(int cityID)
        {
            return await SelectEstablishmentsAsync(cityID, null, null);
        }
        /// <summary>
        /// Select a list of establishments by latitude and longitude.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of establishments.</returns>
        public async Task<Establishments> SelectEstablishmentsAsync(double latitude, double longitude)
        {
            return await SelectEstablishmentsAsync(null, latitude, longitude);
        }
        #endregion

        #region Private Async Methods
        private async Task<Cities> SelectCitiesAsync(string queryText, double? latitude, double? longitude, int[] cityIDs, int? count)
        {
            Cities cities = null;
            CitiesRootObject citiesResponse = null;

            citiesResponse = await webRequest.SelectCitiesAsync(queryText, latitude, longitude, cityIDs, count);

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

        private async Task<Collections> SelectCollectionsAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            Collections collections = null;
            CollectionsRootObject collectionResponse = null;

            collectionResponse = await webRequest.SelectCollectionsAsync(cityID, latitude, longitude, count);

            if (collectionResponse?.Collections == null)
                return collections;

            collections = new Collections();

            foreach (var restaurant in collectionResponse.Collections)
            {
                collections.Add(new Collection
                {
                    ID = restaurant.Collections.ID,
                    Title = restaurant.Collections.Title,
                    Url = restaurant.Collections.Url,
                    Description = restaurant.Collections.Description
                });
            }

            collections.ShareUrl = collectionResponse.ShareUrl;

            return collections;
        }

        private async Task<Cuisines> SelectCuisinesAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            Cuisines cuisines = null;
            CuisinesRootObject cuisinesResponse = null;

            cuisinesResponse = await webRequest.SelectCuisinesAsync(cityID, latitude, longitude, count);

            if (cuisinesResponse?.Cuisines == null)
                return cuisines;

            cuisines = new Cuisines();

            foreach (var cuisine in cuisinesResponse.Cuisines)
                cuisines.Add(new Cuisine
                {
                    ID = cuisine.Cuisines.ID,
                    Name = cuisine.Cuisines.Name
                });

            return cuisines;
        }

        private async Task<Establishments> SelectEstablishmentsAsync(int? cityID, double? latitude, double? longitude)
        {
            Establishments establishments = null;
            EstablishmentsRootObject establishmentsResponse = null;

            establishmentsResponse = await webRequest.SelectEstablishmentsAsync(cityID, latitude, longitude);

            if (establishmentsResponse?.Establishments == null)
                return establishments;

            establishments = new Establishments();

            foreach (var establishment in establishmentsResponse.Establishments)
                establishments.Add(new Establishment
                {
                    ID = establishment.Establishments.ID,
                    Name = establishment.Establishments.Name
                });

            return establishments;
        }
        #endregion
    }
}