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
    public class CollectionsData
    {
        [DeserializeAs(Name = "collections")]
        public List<Collections> Collections { get; set; }

        [DeserializeAs(Name = "has_more")]
        public int HasMore { get; set; }

        [DeserializeAs(Name = "share_url")]
        public string ShareUrl { get; set; }

        [DeserializeAs(Name = "display_text")]
        public string DisplayText { get; set; }

        [DeserializeAs(Name = "has_total")]
        public int HasTotal { get; set; }
    }

    public class Collections
    {
        [DeserializeAs(Name = "collection")]
        public Collection Collection { get; set; }
    }

    public class Collection
    {
        [DeserializeAs(Name = "collection_id")]
        public int ID { get; set; }

        /// <summary>
        /// Number of restaurants in the collection.
        /// </summary>
        [DeserializeAs(Name = "res_count")]
        public int TotalRestaurants { get; set; }

        [DeserializeAs(Name = "image_url")]
        public string ImageUrl { get; set; }

        [DeserializeAs(Name = "url")]
        public string Url { get; set; }

        [DeserializeAs(Name = "title")]
        public string Title { get; set; }

        [DeserializeAs(Name = "description")]
        public string Description { get; set; }

        [DeserializeAs(Name = "share_url")]
        public string ShareUrl { get; set; }
    }
}