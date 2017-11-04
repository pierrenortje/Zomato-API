﻿#region License
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
    internal sealed class ZomatoRestaurantReview
    {
        [JsonProperty("id")]
        internal string ID { get; set; }

        [JsonProperty("rating")]
        internal string Rating { get; set; }

        [JsonProperty("review_text")]
        internal string ReviewText { get; set; }

        [JsonProperty("rating_color")]
        internal string RatingColor { get; set; }

        [JsonProperty("review_time_friendly")]
        internal string ReviewTimeFriendly { get; set; }

        [JsonProperty("rating_text")]
        internal string RatingText { get; set; }

        [JsonProperty("timestamp")]
        internal string Timestamp { get; set; }

        [JsonProperty("likes")]
        internal string Likes { get; set; }

        [JsonProperty("user")]
        internal ZomatoUser User { get; set; }

        [JsonProperty("comments_count")]
        internal string TotalComments { get; set; }

        internal Review ToServiceObject()
        {
            var review = new Review
            {
                ID = this.ID,
                Rating = this.Rating,
                ReviewText = this.ReviewText,
                RatingText = this.RatingText,
                Timestamp = this.Timestamp,
                Likes = this.Likes,
                TotalComments = this.TotalComments,
                User = this.User.ToServiceObject()
            };

            return review;
        }
    }

    internal sealed class ZomatoRestaurantReviews : List<ZomatoRestaurantReview> { }
}