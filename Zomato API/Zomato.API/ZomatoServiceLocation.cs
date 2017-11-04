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
        /// Get Foodie Index, Nightlife Index, Top Cuisines and Best rated restaurants in a given location.
        /// </summary>
        /// <param name="locationID">ID of the location.</param>
        /// <param name="entityType">Name of the entity.</param>
        /// <returns>A list of popular cuisines and nearby restaurants around the given location.</returns>
        public async Task<LocationDetails> SelectLocationDetailsAsync(int? locationID, string entityType)
        {
            LocationDetails locationDetails = null;
            LocationDetailsRootObject locationDetailsResponse = null;

            locationDetailsResponse = await webRequest.SelectLocationDetails(locationID, entityType);

            if (locationDetailsResponse == null)
                return locationDetails;

            locationDetails = locationDetailsResponse.ToServiceObject();

            return locationDetails;
        }
        #endregion

        /// <summary>
        /// Search for Zomato locations by keyword. Provide coordinates to get better search results.
        /// </summary>
        /// <param name="queryText">The text to search for.</param>
        /// <returns>A list of locations.</returns>
        public async Task<Locations> SearchLocationAsync(string queryText, int? count = null)
        {
            return await SearchLocationAsync(queryText, null, null, count);
        }
        /// <summary>
        /// Search for Zomato locations by keyword. Provide coordinates to get better search results.
        /// </summary>
        /// <param name="queryText">The text to search for.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of locations.</returns>
        public async Task<Locations> SearchLocationAsync(string queryText, double? latitude, double? longitude, int? count = null)
        {
            Locations locations = null;
            LocationRootObject zomatoLocations = null;

            zomatoLocations = await webRequest.SearchLocationAsync(queryText, latitude, longitude, count);

            if (zomatoLocations == null)
                return locations;

            locations = zomatoLocations.ToServiceObject();

            return locations;
        }
    }
}