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

namespace Zomato.API.Models
{
    public class RestaurantLocation
    {
        [DeserializeAs(Name = "address")]
        public string Address { get; set; }

        [DeserializeAs(Name = "locality")]
        public string Locality { get; set; }

        [DeserializeAs(Name = "city")]
        public string CityName { get; set; }

        [DeserializeAs(Name = "latitude")]
        public string Latitude { get; set; }

        [DeserializeAs(Name = "longitude")]
        public string Longitude { get; set; }

        [DeserializeAs(Name = "zipcode")]
        public string ZipCode { get; set; }

        [DeserializeAs(Name = "country_id")]
        public string CountryID { get; set; }
    }
}