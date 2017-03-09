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