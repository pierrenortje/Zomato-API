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

using RestSharp.Deserializers;
using System.Collections.Generic;

namespace Zomato.API.Models
{
    public class LocationDetailsData
    {
        [DeserializeAs(Name = "popularity")]
        public string Popularity { get; set; }

        [DeserializeAs(Name = "nightlife_index")]
        public string NightLifeIndex { get; set; }

        [DeserializeAs(Name = "nearby_res")]
        public List<string> NearbyrestaurantIds { get; set; }

        [DeserializeAs(Name = "top_cuisines")]
        public List<string> TopCuisines { get; set; }

        [DeserializeAs(Name = "location")]
        public Location Location { get; set; }

        /// <summary>
        /// Number of restaurants listed.
        /// </summary>
        [DeserializeAs(Name = "num_restaurant")]
        public int RestaurantCount { get; set; }

        [DeserializeAs(Name = "best_rated_restaurant")]
        public List<LocationDetails> Restaurants { get; set; }
    }

    public class LocationDetails
    {
        [DeserializeAs(Name = "restaurant")]
        public Restaurant Restaurant { get; set; }
    }    
}
