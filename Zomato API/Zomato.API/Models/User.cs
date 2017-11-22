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

using RestSharp.Deserializers;

namespace Zomato.API.Models
{
    public class User
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "zomato_handle")]
        public string ZomatoHandle { get; set; }

        /// <summary>
        /// Text for user's foodie level.
        /// </summary>
        [DeserializeAs(Name = "foodie_level")]
        public string FoodieLevel { get; set; }

        /// <summary>
        /// Number to identify user's foodie level; ranges from 0 to 10.
        /// </summary>
        [DeserializeAs(Name = "foodie_level_num")]
        public string FoodieLevelNumber { get; set; }

        /// <summary>
        /// Color hex code used with foodie level on Zomato.
        /// </summary>
        [DeserializeAs(Name = "foodie_color")]
        public string FoodieColor { get; set; }

        [DeserializeAs(Name = "profile_url")]
        public string ProfileUrl { get; set; }

        /// <summary>
        /// Short URL for user's profile on Zomato; for use in apps or social sharing.
        /// </summary>
        [DeserializeAs(Name = "profile_deeplink")]
        public string ProfileDeeplink { get; set; }

        /// <summary>
        /// URL for user's profile image.
        /// </summary>
        [DeserializeAs(Name = "profile_image")]
        public string ProfileImageUrl { get; set; }
    }
}
