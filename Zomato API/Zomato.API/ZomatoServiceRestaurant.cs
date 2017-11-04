﻿#region License
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
        /// <param name="start">The offset to fetch results from.</param>
        /// <param name="count">Amount of results to return.</param>
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

        /// <summary>
        /// Search by location ID.
        /// </summary>
        /// <param name="locationID">The location's ID.</param>
        /// <param name="locationType">The location type.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="start">The offset to fetch results from.</param>
        /// <param name="count">Amount of results to return.</param>
        /// <param name="sort">The sort order.</param>
        /// <param name="order">The order in which to sort.</param>
        /// <returns>A list of restaurants.</returns>
        public async Task<SearchResult> SearchByLocationIDAsync(int locationID, string locationType, double? longitude = null, double? latitude = null, double? radius = null, int? start = null, int? count = null, string sort = null, string order = null)
        {
            return await SearchAsync(locationID, locationType, null, start, count, longitude, latitude, radius, null, null, null, null, sort, order);
        }
        /// <summary>
        /// Search by location ID.
        /// </summary>
        /// <param name="locationID">The location's ID.</param>
        /// <param name="locationType">The location type.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="start">The offset to fetch results from.</param>
        /// <param name="count">Amount of results to return.</param>
        /// <param name="sort">The sort order.</param>
        /// <param name="order">The order in which to sort.</param>
        /// <returns>A list of restaurants.</returns>
        public async Task<SearchResult> SearchByLocationIDCategoriesAsync(int locationID, string locationType, string[] categoryIDs, double? longitude = null, double? latitude = null, double? radius = null, int? start = null, int? count = null, string sort = null, string order = null)
        {
            return await SearchAsync(locationID, locationType, null, start, count, longitude, latitude, radius, null, null, null, string.Join(",", categoryIDs), sort, order);
        }
        /// <summary>
        /// Search by location type.
        /// </summary>
        /// <param name="locationType">The location type.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="start">The offset to fetch results from.</param>
        /// <param name="count">Amount of results to return.</param>
        /// <param name="sort">The sort order.</param>
        /// <param name="order">The order in which to sort.</param>
        /// <returns>A list of restaurants.</returns>
        public async Task<SearchResult> SearchByLocationTypeAsync(string locationType, double? longitude = null, double? latitude = null, double? radius = null, int? start = null, int? count = null, string sort = null, string order = null)
        {
            return await SearchAsync(null, locationType, null, start, count, longitude, latitude, radius, null, null, null, null, sort, order);
        }
        /// <summary>
        /// Search by keyword.
        /// </summary>
        /// <param name="queryText">The keyword to search for.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="start">The offset to fetch results from.</param>
        /// <param name="count">Amount of results to return.</param>
        /// <param name="sort">The sort order.</param>
        /// <param name="order">The order in which to sort.</param>
        /// <returns>A list of restaurants.</returns>
        public async Task<SearchResult> SearchByKeywordAsync(string queryText, double? longitude = null, double? latitude = null, double? radius = null, int? start = null, int? count = null, string sort = null, string order = null)
        {
            return await SearchAsync(null, null, queryText, start, count, longitude, latitude, radius, null, null, null, null, sort, order);
        }
        /// <summary>
        /// Search by longitude and latitude.
        /// </summary>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="start">The offset to fetch results from.</param>
        /// <param name="count">Amount of results to return.</param>
        /// <param name="sort">The sort order.</param>
        /// <param name="order">The order in which to sort.</param>
        /// <returns>A list of restaurants.</returns>
        public async Task<SearchResult> SearchByLocationAsync(double? longitude = null, double? latitude = null, double? radius = null, int? start = null, int? count = null, string sort = null, string order = null)
        {
            return await SearchAsync(null, null, null, start, count, longitude, latitude, radius, null, null, null, null, sort, order);
        }
        /// <summary>
        /// Search by cuisines.
        /// </summary>
        /// <param name="cuisines">An array of cuisines.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="start">The offset to fetch results from.</param>
        /// <param name="count">Amount of results to return.</param>
        /// <param name="sort">The sort order.</param>
        /// <param name="order">The order in which to sort.</param>
        /// <returns>A list of restaurants.</returns>
        public async Task<SearchResult> SearchByCuisineAsync(string[] cuisines, double? longitude = null, double? latitude = null, double? radius = null, int? start = null, int? count = null, string sort = null, string order = null)
        {
            return await SearchAsync(null, null, null, start, count, longitude, latitude, radius, string.Join(",", cuisines), null, null, null, sort, order);
        }
        /// <summary>
        /// Search by establishment ID.
        /// </summary>
        /// <param name="establishmentID">The establishment's ID.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="start">The offset to fetch results from.</param>
        /// <param name="count">Amount of results to return.</param>
        /// <param name="sort">The sort order.</param>
        /// <param name="order">The order in which to sort.</param>
        /// <returns>A list of restaurants.</returns>
        public async Task<SearchResult> SearchByEstablishmentIDAsync(string establishmentID, double? longitude = null, double? latitude = null, double? radius = null, int? start = null, int? count = null, string sort = null, string order = null)
        {
            return await SearchAsync(null, null, null, start, count, longitude, latitude, radius, null, establishmentID, null, null, sort, order);
        }
        /// <summary>
        /// Search by collection ID.
        /// </summary>
        /// <param name="collectionID">The collection's ID.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="start">The offset to fetch results from.</param>
        /// <param name="count">Amount of results to return.</param>
        /// <param name="sort">The sort order.</param>
        /// <param name="order">The order in which to sort.</param>
        /// <returns>A list of restaurants.</returns>
        public async Task<SearchResult> SearchByCollectionIDAsync(string collectionID, double? longitude = null, double? latitude = null, double? radius = null, int? start = null, int? count = null, string sort = null, string order = null)
        {
            return await SearchAsync(null, null, null, start, count, longitude, latitude, radius, null, null, collectionID, null, sort, order);
        }
        /// <summary>
        /// Search by category IDs.
        /// </summary>
        /// <param name="categoryIDs">An array of category IDs.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="start">The offset to fetch results from.</param>
        /// <param name="count">Amount of results to return.</param>
        /// <param name="sort">The sort order.</param>
        /// <param name="order">The order in which to sort.</param>
        /// <returns>A list of restaurants.</returns>
        public async Task<SearchResult> SearchByCategoryIDsAsync(string[] categoryIDs, double? longitude = null, double? latitude = null, double? radius = null, int? start = null, int? count = null, string sort = null, string order = null)
        {
            return await SearchAsync(null, null, null, start, count, longitude, latitude, radius, null, null, null, string.Join(",", categoryIDs), sort, order);
        }
        /// <summary>
        /// Search by category IDs.
        /// </summary>
        /// <param name="categoryIDs">An array of category IDs.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="start">The offset to fetch results from.</param>
        /// <param name="count">Amount of results to return.</param>
        /// <param name="sort">The sort order.</param>
        /// <param name="order">The order in which to sort.</param>
        /// <returns>A list of restaurants.</returns>
        public async Task<SearchResult> SearchAllAsync(int? locationID = null, string locationType = null, string queryText = null, int? start = null, int? count = null, double? longitude = null, double? latitude = null, double? radius = null, string cuisines = null, string establishmentID = null, string collectionID = null, string[] categoryIDs = null, string sort = null, string order = null)
        {
            return await SearchAsync(locationID, locationType, queryText, start, count, latitude, longitude, radius, cuisines, establishmentID, collectionID, categoryIDs != null ? string.Join(",", categoryIDs) : null, sort, order);
        }
        #endregion
    }
}