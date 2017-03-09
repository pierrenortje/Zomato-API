using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class Popularity
    {
        public string PopularityRating { get; set; }
        public string NightlifeIndex { get; set; }
        public List<string> NearbyRestaurantIDs { get; set; }
        public List<string> TopCuisines { get; set; }
        public string TotalPopularityRestaurants { get; set; }
        public string NightlifeRestaurants { get; set; }
        public Subzone Subzone { get; set; }
        public City City { get; set; }
    }
}