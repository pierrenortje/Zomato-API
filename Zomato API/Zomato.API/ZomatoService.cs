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
        #region Private Fields
        private WebRequest webRequest = null;
        #endregion

        #region Constructor
        public ZomatoService()
        {
            webRequest = new WebRequest();
        }
        #endregion

        #region Private Async Methods
        private async Task<Cities> SelectCitiesAsync(string queryText, double? latitude, double? longitude, int[] cityIDs, int? count)
        {
            Cities cities = null;
            CitiesRootObject citiesResponse = null;

            citiesResponse = await webRequest.SelectCitiesAsync(queryText, latitude, longitude, cityIDs, count);

            if (citiesResponse?.LocationSuggestions == null)
                return cities;

            cities = new Cities();

            foreach (var city in citiesResponse.LocationSuggestions)
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

            collections = collectionResponse.ToServiceObject();

            return collections;
        }

        private async Task<Cuisines> SelectCuisinesAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            Cuisines cuisines = null;
            CuisinesRootObject cuisinesResponse = null;

            cuisinesResponse = await webRequest.SelectCuisinesAsync(cityID, latitude, longitude, count);

            if (cuisinesResponse?.Cuisines == null)
                return cuisines;

            cuisines = cuisinesResponse.ToServiceObject();

            return cuisines;
        }

        private async Task<Establishments> SelectEstablishmentsAsync(int? cityID, double? latitude, double? longitude)
        {
            Establishments establishments = null;
            EstablishmentsRootObject establishmentsResponse = null;

            establishmentsResponse = await webRequest.SelectEstablishmentsAsync(cityID, latitude, longitude);

            if (establishmentsResponse?.Establishments == null)
                return establishments;

            establishments = establishmentsResponse.ToServiceObject();

            return establishments;
        }

        private async Task<Geocode> SelectGeocodeAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            Geocode geocode = null;
            GeocodeRootObject geocodeResponse = null;

            geocodeResponse = await webRequest.SelectGeocodeAsync(latitude, longitude);

            if (geocodeResponse == null)
                return geocode;

            geocode = geocodeResponse.ToServiceObject();

            return geocode;
        }

        private async Task<SearchResult> SearchAsync(int? entityID, string entityType, string queryText, int? start, int? count, double? longitude, double? latitude, double? radius, string cuisines, string establishmentID, string collectionID, string categoryIDs, string sort, string order)
        {
            SearchResult searchResult = null;
            SearchRootObject searchResponse = null;

            searchResponse = await webRequest.Search(entityID, entityType, queryText, start, count, latitude, longitude, radius, cuisines, establishmentID, collectionID, categoryIDs, sort, order);

            if (searchResponse == null)
                return searchResult;

            searchResult = searchResponse.ToServiceObject();

            return searchResult;
        }
        #endregion
    }
}