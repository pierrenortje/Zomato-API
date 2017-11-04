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
    internal sealed class EstablishmentResponse
    {
        [JsonProperty("id")]
        internal int ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }
    }

    internal sealed class EstablishmentsResponse
    {
        [JsonProperty("establishment")]
        internal EstablishmentResponse Establishments { get; set; }
    }

    internal sealed class EstablishmentsRootObject
    {
        #region Internal Properties
        [JsonProperty("establishments")]
        internal List<EstablishmentsResponse> Establishments { get; set; }
        #endregion

        #region Internal Methods
        internal Establishments ToServiceObject()
        {
            var establishments = new Establishments();

            foreach (var establishment in this.Establishments)
                establishments.Add(new Establishment
                {
                    ID = establishment.Establishments.ID,
                    Name = establishment.Establishments.Name
                });

            return establishments;
        }
        #endregion
    }
}