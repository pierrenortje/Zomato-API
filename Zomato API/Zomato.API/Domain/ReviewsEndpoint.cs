using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public class ReviewsEndpoint
    {
        public int ReviewsCount { get; set; }
        public int ReviewsStart { get; set; }
        public int ReviewsShown { get; set; }
        public List<Review> Reviews { get; set; }
        public string RespondLink { get; set; }
    }
}
