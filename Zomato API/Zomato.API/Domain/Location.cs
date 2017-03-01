namespace Zomato.API.Domain
{
    public sealed class Location
    {
        public string Title { get; set; }
        public string EntityType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public City City { get; set; }
    }
}