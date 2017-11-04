#region License
// Copyright (c) 2017 Pierre Nortje
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

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