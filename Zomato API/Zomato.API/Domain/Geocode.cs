using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class Geocode
    {
        public Location Location { get; set; }
        public Popularity Popularity { get; set; }
        public string Link { get; set; }
        public NearbyRestaurantList NearbyRestaurantList { get; set; }
    }

    public sealed class NearbyRestaurantList : List<Restaurant> { }
}