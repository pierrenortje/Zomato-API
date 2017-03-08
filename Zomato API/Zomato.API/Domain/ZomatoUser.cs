using Newtonsoft.Json;

namespace Zomato.API.Domain
{
    internal sealed class ZomatoUser
    {
        #region Internal Properties
        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("zomato_handle")]
        internal string ZomatoHandle { get; set; }

        /// <summary>
        /// Text for user's foodie level.
        /// </summary>
        [JsonProperty("foodie_level")]
        internal string FoodieLevel { get; set; }

        /// <summary>
        /// Number to identify user's foodie level; ranges from 0 to 10.
        /// </summary>
        [JsonProperty("foodie_level_num")]
        internal string FoodieLevelNumber { get; set; }

        /// <summary>
        /// Color hex code used with foodie level on Zomato.
        /// </summary>
        [JsonProperty("foodie_color")]
        internal string FoodieColor { get; set; }

        [JsonProperty("profile_url")]
        internal string ProfileUrl { get; set; }

        /// <summary>
        /// Short URL for user's profile on Zomato; for use in apps or social sharing.
        /// </summary>
        [JsonProperty("profile_deeplink")]
        internal string ProfileDeeplink { get; set; }

        /// <summary>
        /// URL for user's profile image.
        /// </summary>
        [JsonProperty("profile_image")]
        internal string ProfileImageUrl { get; set; }
        #endregion

        #region Internal Methods
        internal User ToServiceObject()
        {
            var user = new User
            {
                Name = this.Name,
                ZomatoHandle = this.ZomatoHandle,
                FoodieLevel = this.FoodieLevel,
                FoodieLevelNumber = this.FoodieLevelNumber,
                ProfileUrl = this.ProfileUrl,
                ProfileImageUrl = this.ProfileImageUrl
            };

            return user;
        }
        #endregion
    }
}