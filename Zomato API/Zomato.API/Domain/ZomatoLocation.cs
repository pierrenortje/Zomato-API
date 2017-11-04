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
    internal sealed class ZomatoLocation
    {
        #region Internal Properties
        [JsonProperty("entity_id")]
        internal int ID { get; set; }

        [JsonProperty("entity_type")]
        internal string Type { get; set; }

        [JsonProperty("title")]
        internal string Title { get; set; }

        [JsonProperty("latitude")]
        internal string Latitude { get; set; }

        [JsonProperty("longitude")]
        internal string Longitude { get; set; }

        [JsonProperty("city_id")]
        internal int CityID { get; set; }

        [JsonProperty("city_name")]
        internal string CityName { get; set; }

        [JsonProperty("country_id")]
        internal int CountryID { get; set; }

        [JsonProperty("country_name")]
        internal string CountryName { get; set; }
        #endregion

        #region Internal Methods
        internal Location ToServiceObject()
        {
            var location = new Location
            {
                ID = this.ID,
                Type = this.Type,
                City = new City
                {
                    ID = this.CityID,
                    Name = this.CityName,
                    Country = new Country
                    {
                        ID = this.CountryID,
                        Name = this.CountryName
                    }
                },
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Title = this.Title
            };

            return location;
        }
        #endregion
    }

    internal sealed class ZomatoLocations : List<ZomatoLocation> { }
}