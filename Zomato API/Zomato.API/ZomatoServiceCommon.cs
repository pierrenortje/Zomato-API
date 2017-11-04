#region License
// Copyright (c) 2017 Pierre Nortje
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System.Threading.Tasks;
using Zomato.API.Domain;

namespace Zomato.API
{
    public sealed partial class ZomatoService
    {
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

            categories = categoriesResponse.ToServiceObject();

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
        /// <param name="count">Max results to return.</param>
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

        /// <summary>
        /// Get a food & nightlife index of given coordinates.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns>A list of popular cuisines and nearby restaurants around the given coordinates.</returns>
        public async Task<Geocode> SelectGeocodeAsync(double latitude, double longitude)
        {
            return await SelectGeocodeAsync(null, latitude, longitude, null);
        }
        #endregion
    }
}