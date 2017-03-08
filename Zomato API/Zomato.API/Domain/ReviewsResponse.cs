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