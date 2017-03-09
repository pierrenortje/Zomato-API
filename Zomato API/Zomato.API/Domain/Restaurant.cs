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
        public string[] Cuisines { get; set; }
        public string TotalPhotos { get; set; }
        public string[] PhoneNumbers { get; set; }
        public RestaurantLocation Location { get; set; }
        public Reviews Reviews { get; set; }
        public Photos Photos { get; set; }
    }

    public sealed class Restaurants : List<Restaurant> { }
}