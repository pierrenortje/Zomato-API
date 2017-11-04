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
    internal sealed class CollectionResponse
    {
        [JsonProperty("collection_id")]
        internal int ID { get; set; }

        /// <summary>
        /// Number of restaurants in the collection.
        /// </summary>
        [JsonProperty("res_count")]
        internal int TotalRestaurants { get; set; }

        [JsonProperty("image_url")]
        internal string ImageUrl { get; set; }

        [JsonProperty("url")]
        internal string Url { get; set; }

        [JsonProperty("title")]
        internal string Title { get; set; }

        [JsonProperty("description")]
        internal string Description { get; set; }

        [JsonProperty("share_url")]
        internal string ShareUrl { get; set; }
    }

    internal sealed class CollectionsResponse
    {
        [JsonProperty("collection")]
        internal CollectionResponse Collections { get; set; }
    }

    internal sealed class CollectionsRootObject
    {
        #region Internal Properties
        [JsonProperty("collections")]
        internal List<CollectionsResponse> Collections { get; set; }

        [JsonProperty("has_more")]
        internal int HasMore { get; set; }

        [JsonProperty("share_url")]
        internal string ShareUrl { get; set; }

        [JsonProperty("display_text")]
        internal string DisplayText { get; set; }

        [JsonProperty("has_total")]
        internal int HasTotal { get; set; }
        #endregion

        #region Internal Methods
        internal Collections ToServiceObject()
        {
            var collections = new Collections();

            foreach (var restaurant in this.Collections)
                collections.Add(new Collection
                {
                    ID = restaurant.Collections.ID,
                    Title = restaurant.Collections.Title,
                    Url = restaurant.Collections.Url,
                    Description = restaurant.Collections.Description
                });

            collections.ShareUrl = this.ShareUrl;

            return collections;
        }
        #endregion
    }
}