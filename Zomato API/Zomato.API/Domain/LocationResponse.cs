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

namespace Zomato.API.Domain
{
    internal sealed class LocationRootObject
    {
        #region Internal Properties
        [JsonProperty("location_suggestions")]
        internal ZomatoLocations Locations { get; set; }

        [JsonProperty("status")]
        internal string Status { get; set; }

        [JsonProperty("has_more")]
        internal int HasMore { get; set; }

        [JsonProperty("has_total")]
        internal int HasTotal { get; set; }
        #endregion

        #region Internal Methods
        internal Locations ToServiceObject()
        {
            var locations = new Locations();

            if (this.Locations.Count > 0)
            {
                foreach (var location in this.Locations)
                    locations.Add(location.ToServiceObject());
            }

            return locations;
        }
        #endregion
    }
}