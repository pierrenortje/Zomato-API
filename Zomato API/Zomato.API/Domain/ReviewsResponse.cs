using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{

    internal sealed class UserReview
    {
        [JsonProperty("review")]
        internal ZomatoRestaurantReview Review { get; set; }
    }

    internal sealed class ReviewsRootObject
    {
        #region Internal Properties
        [JsonProperty("reviews_count")]
        internal int ReviewsCount { get; set; }

        [JsonProperty("reviews_start")]
        internal int? ReviewsStart { get; set; }

        [JsonProperty("reviews_shown")]
        internal int? ReviewsShown { get; set; }

        [JsonProperty("user_reviews")]
        internal List<UserReview> UserReviews { get; set; }

        [JsonProperty("Respond to reviews via Zomato Dashboard")]
        internal string RespondLink { get; set; }
        #endregion

        #region Internal Methods
        internal ReviewsEndpoint ToServiceObject()
        {
            ReviewsShown = ReviewsShown.HasValue ? ReviewsShown : 0;
            ReviewsStart = ReviewsStart.HasValue ? ReviewsStart : 0;

            var reviewsEndpoint = new ReviewsEndpoint
            {
                ReviewsCount = this.ReviewsCount,
                ReviewsShown = (int) this.ReviewsShown,
                ReviewsStart = (int) this.ReviewsStart,
                Reviews = new List<Review>()
            };

            foreach (var zomatoReview in this.UserReviews) {
                reviewsEndpoint.Reviews.Add(zomatoReview.Review.ToServiceObject());
            }

            return reviewsEndpoint;
        }
        #endregion
    }


}
