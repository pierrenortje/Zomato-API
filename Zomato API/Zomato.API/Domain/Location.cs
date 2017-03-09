using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class Location
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public City City { get; set; }
    }
    public sealed class Locations : List<Location> { }
}