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
    internal sealed class ZomatoPopularity
    {
        [JsonProperty("popularity")]
        internal string PopularityRating { get; set; }

        [JsonProperty("nightlife_index")]
        internal string NightlifeIndex { get; set; }

        /// <summary>
        /// List of nearby restaurants' IDs.
        /// </summary>
        [JsonProperty("nearby_res")]
        internal List<string> NearbyRestaurantIDs { get; set; }

        [JsonProperty("top_cuisines")]
        internal List<string> TopCuisines { get; set; }

        [JsonProperty("popularity_res")]
        internal string TotalPopularityRestaurants { get; set; }

        [JsonProperty("nightlife_res")]
        internal string NightlifeRestaurants { get; set; }

        [JsonProperty("subzone")]
        internal string SubzoneName { get; set; }

        [JsonProperty("subzone_id")]
        internal int SubzoneID { get; set; }

        [JsonProperty("city")]
        internal string CityName { get; set; }
    }
}