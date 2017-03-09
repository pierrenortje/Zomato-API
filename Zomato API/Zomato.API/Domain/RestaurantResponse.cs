using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class ZomatoRestaurant
    {
        #region Internal Properties
        [JsonProperty("id")]
        internal string ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("url")]
        internal string Url { get; set; }

        [JsonProperty("location")]
        internal ZomatoRestaurantLocation Location { get; set; }

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
        internal string FeaturedImageUrl { get; set; }

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
        internal ZomatoUserRating UserRating { get; set; }

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
        internal ZomatoPhotos Photos { get; set; }

        [JsonProperty("all_reviews")]
        internal ZomatoRestaurantReviews Reviews { get; set; }
        #endregion

        #region Internal Methods
        internal Restaurant ToServiceObject()
        {
            var restaurant = new Restaurant
            {
                ID = this.ID,
                Name = this.Name,
                Url = this.Url,
                EventsUrl = this.EventsUrl,
                MenuUrl = this.MenuUrl,
                PhotosUrl = this.PhotosUrl,
                ThumbUrl = this.ThumbUrl,
                Cuisines = this.Cuisines?.Split(','),
                PriceRange = this.PriceRange,
                AverageCostForTwo = this.AverageCostForTwo,
                PhoneNumbers = this.PhoneNumbers?.Split(','),
                FeaturedImageUrl = this.FeaturedImageUrl,
                TotalPhotos = this.TotalPhotos
            };

            if (this.Location != null)
                restaurant.Location = this.Location.ToServiceObject();

            #region Photos
            if (this.Photos != null)
                foreach (var photo in this.Photos)
                    restaurant.Photos.Add(photo.ToServiceObject());
            #endregion

            #region Reviews
            if (this.Reviews != null)
                foreach (var review in this.Reviews)
                    restaurant.Reviews.Add(review.ToServiceObject());
            #endregion

            return restaurant;
        }
        #endregion
    }

    internal sealed class ZomatoRestaurants : List<ZomatoRestaurant> { }
}