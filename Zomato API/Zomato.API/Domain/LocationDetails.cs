using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class LocationDetails
    {
        public Location Location { get; set; }
        public Popularity Popularity { get; set; }
        public int RestaurantCount { get; set; }
        public BestRatedRestaurantList BestRatedRestaurantList { get; set; }
    }

    public sealed class BestRatedRestaurantList : List<Restaurant> { }

}
