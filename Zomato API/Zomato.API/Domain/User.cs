namespace Zomato.API.Domain
{
    public sealed class User
    {
        public string Name { get; set; }
        public string ZomatoHandle { get; set; }
        public string FoodieLevel { get; set; }
        public string FoodieLevelNumber { get; set; }
        public string ProfileUrl { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}