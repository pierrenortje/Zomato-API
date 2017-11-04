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
    internal sealed class ZomatoPhoto
    {
        #region Internal Properties
        [JsonProperty("id")]
        internal string ID { get; set; }

        [JsonProperty("url")]
        internal string Url { get; set; }

        [JsonProperty("thumb_url")]
        internal string ThumbUrl { get; set; }

        [JsonProperty("user")]
        internal ZomatoUser User { get; set; }

        /// <summary>
        /// ID of restaurant for which the image was uploaded.
        /// </summary>
        [JsonProperty("res_id")]
        internal string RestaurantID { get; set; }

        [JsonProperty("caption")]
        internal string Caption { get; set; }

        [JsonProperty("timestamp")]
        internal string Timestamp { get; set; }

        [JsonProperty("friendly_time")]
        internal string FriendlyTime { get; set; }

        [JsonProperty("width")]
        internal string Width { get; set; }

        [JsonProperty("height")]
        internal string Height { get; set; }

        [JsonProperty("comments_count")]
        internal string TotalComments { get; set; }

        [JsonProperty("likes_count")]
        internal string LikesCount { get; set; }
        #endregion

        #region Internal Methods
        internal Photo ToServiceObject()
        {
            var photo = new Photo
            {
                ID = this.ID,
                Caption = this.Caption,
                Height = this.Height,
                Width = this.Width,
                LikesCount = this.LikesCount,
                RestaurantID = this.RestaurantID,
                ThumbUrl = this.ThumbUrl,
                Timestamp = this.Timestamp,
                TotalComments = this.TotalComments,
                Url = this.Url,
                User = this.User.ToServiceObject()
            };

            return photo;
        }
        #endregion
    }

    internal sealed class ZomatoPhotos : List<ZomatoPhoto> { }
}