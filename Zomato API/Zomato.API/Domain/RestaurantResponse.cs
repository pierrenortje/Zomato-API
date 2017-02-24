using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class RestaurantLocation
    {
        [JsonProperty("address")]
        internal string Address { get; set; }

        [JsonProperty("locality")]
        internal string Locality { get; set; }

        [JsonProperty("city")]
        internal string City { get; set; }

        [JsonProperty("latitude")]
        internal string Latitude { get; set; }

        [JsonProperty("longitude")]
        internal string Longitude { get; set; }

        [JsonProperty("zipcode")]
        internal string ZipCode { get; set; }

        [JsonProperty("country_id")]
        internal string CountryID { get; set; }
    }

    internal sealed class UserRating
    {
        [JsonProperty("aggregate_rating")]
        internal string AggregateRating { get; set; }

        [JsonProperty("rating_text")]
        internal string RatingText { get; set; }

        [JsonProperty("rating_color")]
        internal string RatingColor { get; set; }

        [JsonProperty("votes")]
        internal string Votes { get; set; }
    }

    internal sealed class ZomatoUser
    {
        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("zomato_handle")]
        internal string ZomatoHandle { get; set; }

        /// <summary>
        /// Text for user's foodie level.
        /// </summary>
        [JsonProperty("foodie_level")]
        internal string FoodieLevel { get; set; }

        /// <summary>
        /// Number to identify user's foodie level; ranges from 0 to 10.
        /// </summary>
        [JsonProperty("foodie_level_num")]
        internal string FoodieLevelNumber { get; set; }

        /// <summary>
        /// Color hex code used with foodie level on Zomato.
        /// </summary>
        [JsonProperty("foodie_color")]
        internal string FoodieColor { get; set; }

        [JsonProperty("profile_url")]
        internal string ProfileUrl { get; set; }

        /// <summary>
        /// Short URL for user's profile on Zomato; for use in apps or social sharing.
        /// </summary>
        [JsonProperty("profile_deeplink")]
        internal string ProfileDeeplink { get; set; }

        /// <summary>
        /// URL for user's profile image.
        /// </summary>
        [JsonProperty("profile_image")]
        internal string ProfileImageUrl { get; set; }
    }

    internal sealed class RestaurantPhoto
    {
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
    }

    internal sealed class RestaurantReview
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
    }

    internal sealed class RestaurantRootObject
    {
        [JsonProperty("id")]
        internal string ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("url")]
        internal string Url { get; set; }

        [JsonProperty("location")]
        internal RestaurantLocation Location { get; set; }

        [JsonProperty("average_cost_for_two")]
        internal string AverageCostForTwo { get; set; }

        [JsonProperty("price_range")]
        internal string PriceRange { get; set; }

        [JsonProperty("currency")]
        internal string Currency { get; set; }

        /// <summary>
        /// URL of the low resolution header image of restaurant.
        /// </summary>
        [JsonProperty("thumb")]
        internal string ThumbUrl { get; set; }

        /// <summary>
        /// URL of the high resolution header image of restaurant.
        /// </summary>
        [JsonProperty("featured_image")]
        internal string FeaturedImage { get; set; }

        /// <summary>
        /// URL of the restaurant's photos page.
        /// </summary>
        [JsonProperty("photos_url")]
        internal string PhotosUrl { get; set; }

        /// <summary>
        /// URL of the restaurant's menu page.
        /// </summary>
        [JsonProperty("menu_url")]
        internal string MenuUrl { get; set; }

        /// <summary>
        /// URL of the restaurant's events page.
        /// </summary>
        [JsonProperty("events_url")]
        internal string EventsUrl { get; set; }

        [JsonProperty("user_rating")]
        internal UserRating UserRating { get; set; }

        [JsonProperty("has_online_delivery")]
        internal string HasOnlineDelivery { get; set; }

        [JsonProperty("is_delivering_now")]
        internal string IsDeliveringNow { get; set; }

        [JsonProperty("has_table_booking")]
        internal string HasTableBooking { get; set; }

        [JsonProperty("deeplink")]
        internal string Deeplink { get; set; }

        [JsonProperty("cuisines")]
        internal string Cuisines { get; set; }

        [JsonProperty("all_reviews_count")]
        internal string TotalReviews { get; set; }

        [JsonProperty("photo_count")]
        internal string TotalPhotos { get; set; }

        [JsonProperty("phone_numbers")]
        internal string PhoneNumbers { get; set; }

        [JsonProperty("photos")]
        internal List<RestaurantPhoto> Photos { get; set; }

        [JsonProperty("all_reviews")]
        internal List<RestaurantReview> Reviews { get; set; }
    }
}