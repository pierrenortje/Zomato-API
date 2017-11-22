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
using System.Collections.Generic;

namespace Zomato.API.Models
{
    public class ReviewsData
    {
        [DeserializeAs(Name = "reviews_count")]
        public int ReviewsCount { get; set; }

        [DeserializeAs(Name = "reviews_start")]
        public int ReviewsStart { get; set; }

        [DeserializeAs(Name = "reviews_shown")]
        public int ReviewsShown { get; set; }

        [DeserializeAs(Name = "user_reviews")]
        public List<Reviews> UserReviews { get; set; }

        [DeserializeAs(Name = "Respond to reviews via Zomato Dashboard")]
        public string RespondLink { get; set; }
    }

    public class Reviews
    {
        [DeserializeAs(Name = "review")]
        public Review Review { get; set; }
    }
}
