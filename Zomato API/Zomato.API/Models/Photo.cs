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
    public class Photo
    {
        [DeserializeAs(Name = "id")]
        public string ID { get; set; }

        [DeserializeAs(Name = "url")]
        public string Url { get; set; }

        [DeserializeAs(Name = "thumb_url")]
        public string ThumbUrl { get; set; }

        [DeserializeAs(Name = "user")]
        public User User { get; set; }

        /// <summary>
        /// ID of restaurant for which the image was uploaded.
        /// </summary>
        [DeserializeAs(Name = "res_id")]
        public string restaurantId { get; set; }

        [DeserializeAs(Name = "caption")]
        public string Caption { get; set; }

        [DeserializeAs(Name = "timestamp")]
        public string Timestamp { get; set; }

        [DeserializeAs(Name = "friendly_time")]
        public string FriendlyTime { get; set; }

        [DeserializeAs(Name = "width")]
        public string Width { get; set; }

        [DeserializeAs(Name = "height")]
        public string Height { get; set; }

        [DeserializeAs(Name = "comments_count")]
        public string TotalComments { get; set; }

        [DeserializeAs(Name = "likes_count")]
        public string LikesCount { get; set; }
    }
}
