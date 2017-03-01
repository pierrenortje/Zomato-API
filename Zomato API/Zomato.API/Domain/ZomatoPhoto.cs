using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class ZomatoPhoto
    {
        [JsonProperty("id")]
        internal string ID { get; set; }

        [JsonProperty("url")]
        internal string Url { get; set; }

        [JsonProperty("thumb_url")]
        internal string ThumbUrl { get; set; }

        [JsonProperty("user")]
        internal ZomatoUser User { get; set; }

        /// <summary>
        /// ID of restaurant for which the image was uploaded.
        /// </summary>
        [JsonProperty("res_id")]
        internal string RestaurantID { get; set; }

        [JsonProperty("caption")]
        internal string Caption { get; set; }

        [JsonProperty("timestamp")]
        internal string Timestamp { get; set; }

        [JsonProperty("friendly_time")]
        internal string FriendlyTime { get; set; }

        [JsonProperty("width")]
        internal string Width { get; set; }

        [JsonProperty("height")]
        internal string Height { get; set; }

        [JsonProperty("comments_count")]
        internal string TotalComments { get; set; }

        [JsonProperty("likes_count")]
        internal string LikesCount { get; set; }
    }

    internal sealed class ZomatoPhotos : List<ZomatoPhoto> { }
}