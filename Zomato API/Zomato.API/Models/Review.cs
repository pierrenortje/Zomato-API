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
    public class Review
    {
        [DeserializeAs(Name = "id")]
        public string ID { get; set; }

        [DeserializeAs(Name = "rating")]
        public string Rating { get; set; }

        [DeserializeAs(Name = "review_text")]
        public string ReviewText { get; set; }

        [DeserializeAs(Name = "rating_color")]
        public string RatingColor { get; set; }

        [DeserializeAs(Name = "review_time_friendly")]
        public string ReviewTimeFriendly { get; set; }

        [DeserializeAs(Name = "rating_text")]
        public string RatingText { get; set; }

        [DeserializeAs(Name = "timestamp")]
        public string Timestamp { get; set; }

        [DeserializeAs(Name = "likes")]
        public string Likes { get; set; }

        [DeserializeAs(Name = "user")]
        public User User { get; set; }

        [DeserializeAs(Name = "comments_count")]
        public string TotalComments { get; set; }
    }
}
