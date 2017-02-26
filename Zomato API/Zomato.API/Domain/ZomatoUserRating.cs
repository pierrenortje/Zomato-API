using Newtonsoft.Json;

namespace Zomato.API.Domain
{
    internal sealed class ZomatoUserRating
    {
        [JsonProperty("aggregate_rating")]
        internal string AggregateRating { get; set; }

        [JsonProperty("rating_text")]
        internal string RatingText { get; set; }

        [JsonProperty("rating_color")]
        internal string RatingColor { get; set; }

        [JsonProperty("votes")]
        internal string Votes { get; set; }
    }
}