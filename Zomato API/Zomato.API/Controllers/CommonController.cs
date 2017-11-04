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
    internal sealed class CommonController : BaseController { }

    internal sealed class CommonAction
    {
        #region Actions
        /// <summary>
        /// Get a list of categories. List of all restaurants categorized under a particular
        /// restaurant type can be obtained using /Search API with Category ID as inputs.
        /// </summary>
        internal const string SelectCategories = "categories";

        /// <summary>
        /// Find the Zomato ID and other details for a city .
        /// </summary>
        internal const string SelectCities = "cities";

        /// <summary>
        /// Returns Zomato Restaurant Collections in a City.
        /// </summary>
        internal const string SelectCollections = "collections";

        /// <summary>
        /// Get a list of all cuisines of restaurants listed in a city.
        /// </summary>
        internal const string SelectCuisines = "cuisines";

        /// <summary>
        /// Get a list of restaurant types in a city.
        /// </summary>
        internal const string SelectEstablishments = "establishments";

        /// <summary>
        /// Get Foodie and Nightlife Index, list of popular cuisines and nearby restaurants around the given coordinates.
        /// </summary>
        internal const string SelectGeocode = "geocode";
        #endregion
    }
}