using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class Geocode
    {
        public Region region { get; set; }
        public Popularity popularity { get; set; }
        public string link { get; set; }

        public NearbyRestaurantList nearbyRestaurantList { get; set; }

        public string entityType { get; set; }

        public int entityID { get; set; }
        public int cityID { get; set; }
        public int countryID { get; set; }
        public int subZoneID { get; set; }

        public List<string> nearbyResIDs = new List<string>();
    }

    public sealed class NearbyRestaurantList : List<Restaurant>
    {
    }


}
