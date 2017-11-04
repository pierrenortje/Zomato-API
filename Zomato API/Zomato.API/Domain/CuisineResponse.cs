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
    internal sealed class CuisineResponse
    {
        [JsonProperty("cuisine_id")]
        internal int ID { get; set; }

        [JsonProperty("cuisine_name")]
        internal string Name { get; set; }
    }

    internal sealed class CuisinesResponse
    {
        [JsonProperty("cuisine")]
        internal CuisineResponse Cuisines { get; set; }
    }

    internal sealed class CuisinesRootObject
    {
        #region Internal Properties
        [JsonProperty("cuisines")]
        internal List<CuisinesResponse> Cuisines { get; set; }
        #endregion

        #region Internal Methods
        internal Cuisines ToServiceObject()
        {
            var cuisines = new Cuisines();

            foreach (var cuisine in this.Cuisines)
                cuisines.Add(new Cuisine
                {
                    ID = cuisine.Cuisines.ID,
                    Name = cuisine.Cuisines.Name
                });

            return cuisines;
        }
        #endregion
    }
}