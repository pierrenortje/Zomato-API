using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class Restaurant
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string AverageCostForTwo { get; set; }
        public string PriceRange { get; set; }
        public string ThumbUrl { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string PhotosUrl { get; set; }
        public string MenuUrl { get; set; }
        public string EventsUrl { get; set; }
        public string Cuisines { get; set; }
        public string TotalPhotos { get; set; }
        public string PhoneNumbers { get; set; }
        public RestaurantLocation Location { get; set; }
        public Reviews Reviews { get; set; }
        public Photos Photos { get; set; }
    }

    public sealed class Photo
    {
        public string ID { get; set; }
        public string Url { get; set; }
        public string ThumbUrl { get; set; }
        public string RestaurantID { get; set; }
        public string Caption { get; set; }
        public string Timestamp { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string TotalComments { get; set; }
        public string LikesCount { get; set; }
        public User User { get; set; }
    }
    public sealed class Photos : List<Photo> { }

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

    public sealed class User
    {
        public string Name { get; set; }
        public string ZomatoHandle { get; set; }
        public string FoodieLevel { get; set; }
        public string FoodieLevelNumber { get; set; }
        public string ProfileUrl { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}