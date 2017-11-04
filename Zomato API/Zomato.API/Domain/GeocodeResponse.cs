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

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class NearbyRestaurants
    {
        [JsonProperty("restaurant")]
        internal ZomatoRestaurant Restaurants { get; set; }
    }

    internal sealed class GeocodeRootObject
    {
        #region Internal Properties
        [JsonProperty("location")]
        internal ZomatoLocation Location { get; set; }

        [JsonProperty("popularity")]
        internal ZomatoPopularity Popularity { get; set; }

        /// <summary>
        /// URL of the web search page of the locality.
        /// </summary>
        [JsonProperty("link")]
        internal string Link { get; set; }

        [JsonProperty("nearby_restaurants")]
        internal List<NearbyRestaurants> Restaurants { get; set; }
        #endregion

        #region Internal Methods
        internal Geocode ToServiceObject()
        {
            var geocode = new Geocode
            {
                Location = this.Location.ToServiceObject(),
                Link = this.Link,
                Popularity = new Popularity
                {
                    City = new City
                    {
                        Name = this.Popularity.CityName
                    },
                    Subzone = new Subzone
                    {
                        ID = this.Popularity.SubzoneID,
                        Name = this.Popularity.SubzoneName
                    },
                    NearbyRestaurantIDs = this.Popularity.NearbyRestaurantIDs,
                    NightlifeIndex = this.Popularity.NightlifeIndex,
                    NightlifeRestaurants = this.Popularity.NightlifeRestaurants,
                    PopularityRating = this.Popularity.PopularityRating,
                    TopCuisines = this.Popularity.TopCuisines,
                    TotalPopularityRestaurants = this.Popularity.TotalPopularityRestaurants
                },
                NearbyRestaurantList = new NearbyRestaurantList()
            };

            foreach (var zomatoRestaurant in this.Restaurants)
                geocode.NearbyRestaurantList.Add(zomatoRestaurant.Restaurants.ToServiceObject());

            return geocode;
        }
        #endregion
    }
}