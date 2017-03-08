namespace Zomato.API.Domain
{
    public sealed class ReviewCollection
    {
        public int ReviewsCount { get; set; }
        public int ReviewsStart { get; set; }
        public int ReviewsShown { get; set; }
        public Reviews Reviews { get; set; }
        public string RespondLink { get; set; }
    }
}   