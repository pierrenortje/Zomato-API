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

namespace Zomato.API.Controllers
{
    internal sealed class RestaurantController : BaseController { }

    internal sealed class RestaurantAction
    {
        #region Actions
        /// <summary>
        /// Get daily menu using Zomato restaurant ID.
        /// </summary>
        internal const string GetDailyMenu = "dailymenu";

        /// <summary>
        /// Get detailed restaurant information using Zomato restaurant ID. Partner Access is required to access photos and reviews.
        /// </summary>
        internal const string Get = "restaurant";

        /// <summary>
        /// Get restaurant reviews using the Zomato restaurant ID.
        /// </summary>
        internal const string SelectReviews = "reviews";

        /// <summary>
        /// The location input can be specified using Zomato location ID or coordinates.
        /// Cuisine / Establishment / Collection IDs can be obtained from respective api calls.
        /// Partner Access is required to access photos and reviews.
        /// </summary>
        internal const string Search = "search";
        #endregion
    }
}