using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class Review
    {
        public string ID { get; set; }
        public string Rating { get; set; }
        public string ReviewText { get; set; }
        public string RatingText { get; set; }
        public string Timestamp { get; set; }
        public string Likes { get; set; }
        public string TotalComments { get; set; }
        public User User { get; set; }
    }

    public sealed class Reviews : List<Review> { }
}