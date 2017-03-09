using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class Photo
    {
        public string ID { get; set; }
        public string Url { get; set; }
        public string ThumbUrl { get; set; }
        public string RestaurantID { get; set; }
        public string Caption { get; set; }
        public string Timestamp { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string TotalComments { get; set; }
        public string LikesCount { get; set; }
        public User User { get; set; }
    }

    public sealed class Photos : List<Photo> { }
}