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
    internal sealed class ZomatoCity
    {
        [JsonProperty("id")]
        internal int ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("country_id")]
        internal int CountryID { get; set; }

        [JsonProperty("country_name")]
        internal string CountryName { get; set; }

        [JsonProperty("is_state")]
        internal int IsState { get; set; }

        [JsonProperty("state_id")]
        internal int StateID { get; set; }

        [JsonProperty("state_name")]
        internal string StateName { get; set; }

        [JsonProperty("state_code")]
        internal string StateCode { get; set; }
    }

    internal sealed class ZomatoCities : List<ZomatoCity> { }
}