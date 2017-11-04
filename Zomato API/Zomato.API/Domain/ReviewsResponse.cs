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
    internal sealed class UserReview
    {
        [JsonProperty("review")]
        internal ZomatoRestaurantReview Review { get; set; }
    }
    internal sealed class UserReviews : List<UserReview> { }

    internal sealed class ReviewsRootObject
    {
        #region Internal Properties
        [JsonProperty("reviews_count")]
        internal int ReviewsCount { get; set; }

        [JsonProperty("reviews_start")]
        internal int ReviewsStart { get; set; }

        [JsonProperty("reviews_shown")]
        internal int ReviewsShown { get; set; }

        [JsonProperty("user_reviews")]
        internal UserReviews UserReviews { get; set; }

        [JsonProperty("Respond to reviews via Zomato Dashboard")]
        internal string RespondLink { get; set; }
        #endregion

        #region Internal Methods
        internal ReviewCollection ToServiceObject()
        {
            var reviewsEndpoint = new ReviewCollection
            {
                ReviewsCount = this.ReviewsCount,
                ReviewsShown = this.ReviewsShown,
                ReviewsStart = this.ReviewsStart,
                Reviews = new Reviews()
            };

            foreach (var zomatoReview in this.UserReviews)
                reviewsEndpoint.Reviews.Add(zomatoReview.Review.ToServiceObject());

            return reviewsEndpoint;
        }
        #endregion
    }
}