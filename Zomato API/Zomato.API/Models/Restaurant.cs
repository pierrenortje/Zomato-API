#region License
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

using RestSharp.Deserializers;
using System.Collections.Generic;

namespace Zomato.API.Models
{
    public class Restaurant
    {
        [DeserializeAs(Name = "id")]
        public string ID { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "url")]
        public string Url { get; set; }

        [DeserializeAs(Name = "location")]
        public RestaurantLocation Location { get; set; }

        [DeserializeAs(Name = "average_cost_for_two")]
        public string AverageCostForTwo { get; set; }

        [DeserializeAs(Name = "price_range")]
        public string PriceRange { get; set; }

        [DeserializeAs(Name = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// URL of the low resolution header image of restaurant.
        /// </summary>
        [DeserializeAs(Name = "thumb")]
        public string ThumbUrl { get; set; }

        /// <summary>
        /// URL of the high resolution header image of restaurant.
        /// </summary>
        [DeserializeAs(Name = "featured_image")]
        public string FeaturedImageUrl { get; set; }

        /// <summary>
        /// URL of the restaurant's photos page.
        /// </summary>
        [DeserializeAs(Name = "photos_url")]
        public string PhotosUrl { get; set; }

        /// <summary>
        /// URL of the restaurant's menu page.
        /// </summary>
        [DeserializeAs(Name = "menu_url")]
        public string MenuUrl { get; set; }

        /// <summary>
        /// URL of the restaurant's events page.
        /// </summary>
        [DeserializeAs(Name = "events_url")]
        public string EventsUrl { get; set; }

        [DeserializeAs(Name = "user_rating")]
        public UserRating UserRating { get; set; }

        [DeserializeAs(Name = "has_online_delivery")]
        public string HasOnlineDelivery { get; set; }

        [DeserializeAs(Name = "is_delivering_now")]
        public string IsDeliveringNow { get; set; }

        [DeserializeAs(Name = "has_table_booking")]
        public string HasTableBooking { get; set; }

        [DeserializeAs(Name = "deeplink")]
        public string Deeplink { get; set; }

        [DeserializeAs(Name = "cuisines")]
        public string Cuisines { get; set; }

        [DeserializeAs(Name = "all_reviews_count")]
        public string TotalReviews { get; set; }

        [DeserializeAs(Name = "photo_count")]
        public string TotalPhotos { get; set; }

        [DeserializeAs(Name = "phone_numbers")]
        public string PhoneNumbers { get; set; }

        [DeserializeAs(Name = "photos")]
        public List<Photo> Photos { get; set; }

        [DeserializeAs(Name = "all_reviews")]
        public List<Review> Reviews { get; set; }
    }
}
