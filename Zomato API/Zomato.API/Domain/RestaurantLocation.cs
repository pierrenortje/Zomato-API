namespace Zomato.API.Domain
{
    public sealed class RestaurantLocation
    {
        public string Address { get; set; }
        public string CityName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ZipCode { get; set; }
    }
}