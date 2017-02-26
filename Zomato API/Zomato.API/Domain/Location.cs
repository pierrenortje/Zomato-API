namespace Zomato.API.Domain
{
    public class Location
    {
        internal string Title { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public City City { get; set; }
    }
}