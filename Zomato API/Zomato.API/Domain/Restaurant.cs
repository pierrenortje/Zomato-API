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

using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class Restaurant
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string AverageCostForTwo { get; set; }
        public string AggregateRating { get; set; }
        public string Votes { get; set; }
        public string PriceRange { get; set; }
        public string ThumbUrl { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string PhotosUrl { get; set; }
        public string MenuUrl { get; set; }
        public string EventsUrl { get; set; }
        public string[] Cuisines { get; set; }
        public string TotalPhotos { get; set; }
        public string[] PhoneNumbers { get; set; }
        public RestaurantLocation Location { get; set; }
        public Reviews Reviews { get; set; }
        public Photos Photos { get; set; }
    }

    public sealed class Restaurants : List<Restaurant> { }
}