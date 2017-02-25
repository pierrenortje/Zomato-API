using System;
using System.Linq;
using System.Threading.Tasks;
using Zomato.API.Domain;

/*
 * TODO: 2017-02-18 - pierre.nortje - Need to add support for the "Location"- and "Restaurant"-controller.
 */
namespace Zomato.API.Demo
{
    /// <summary>
    /// Description:
    ///     • Zomato APIs give you access to the freshest and most exhaustive information for
    ///       over 1.5 million restaurants across 10,000 cities globally. 
    ///       
    /// Documentation:
    ///     • View documentation at: https://developers.zomato.com/documentation
    ///     
    /// Notes:
    ///     • Zomato limits to 1000 calls/day (see https://developers.zomato.com/api)
    ///     
    /// Zomato API Key:
    ///     • 469e676c2fd3ab263e191cc78e2ae876
    /// 
    /// Zomato Enpoints:
    /// 
    ///     CommonController:
    ///         • GET /categories           [COMPLETED]
    ///         • GET /cities               [COMPLETED]
    ///         • GET /collections          [COMPLETED]
    ///         • GET /cuisines             [TBC]
    ///         • GET /establishments       [TBC]
    ///         • GET /geocode              [TBC]
    ///         
    ///     LocationCommonController:
    ///         • GET /location_details     [TBC]
    ///         • GET /locations            [TBC]
    ///         
    ///     RestaurantController:
    ///         • GET /dailymenu            [TBC]
    ///         • GET /restaurant           [TBC]
    ///         • GET /reviews              [TBC]
    ///         • GET /search               [TBC]
    ///         
    /// Acronyms:
    ///     • TBC: To be completed.
    /// </summary>
    class Program
    {
        #region Private Static Fields
        private static ZomatoService zomatoService = new ZomatoService();

        private static string cityName = "Cape Town";

        private static double longitude = -33.9249;
        private static double latitude = 18.4241;

        private static int[] cityIDs = new int[] { 64 };
        #endregion

        #region Public Static Methods
        public static void Main(string[] args)
        {
            Task.Run(() => MainAsync());

            Console.ReadLine();
        }
        #endregion

        #region Private Static Methods
        private static async void MainAsync()
        {
            //await SelectCategoriesAsync();

            //await SelectCitiesAsync(cityName);
            //await SelectCitiesAsync(cityName, 5);
            //await SelectCitiesAsync(longitude, latitude);
            //await SelectCitiesAsync(cityIDs);

            //await SelectCollectionsAsync(64);

            //await SelectCuisinesAsync(64);
            //await SelectCuisinesAsync(longitude, latitude);

            await SelectGeocodeAsync(40.7, -73.9);
        }
        #endregion

        #region Categories
        private static async Task SelectCategoriesAsync()
        {
            var categories = await zomatoService.SelectCategoriesAsync();

            if (categories == null)
                throw new Exception("No categories found.");

            Console.WriteLine(new string('=', 20));
            Console.WriteLine("All categories.");
            Console.WriteLine(new string('=', 20));

            foreach (var category in categories)
                Console.WriteLine($"ID: {category.ID}.\tName: {category.Name}.");

            Console.WriteLine("\n\n");
        }
        #endregion

        #region Cities
        private static async Task SelectCitiesAsync(string queryText, int? count = null)
        {
            var cities = await zomatoService.SelectCitiesAsync(queryText, count);

            PrintCitiesResponse(cities, "Cities by name.");
        }
        private static async Task SelectCitiesAsync(int[] cityIDs, int? count = null)
        {
            var cities = await zomatoService.SelectCitiesAsync(cityIDs, count);

            PrintCitiesResponse(cities, "Cities by city IDs.");
        }
        private static async Task SelectCitiesAsync(double latitude, double longitude, int? count = null)
        {
            var cities = await zomatoService.SelectCitiesAsync(latitude, longitude, count);

            PrintCitiesResponse(cities, "Cities by latitude and longitude.");
        }

        private static void PrintCitiesResponse(Cities cities, string customMessage)
        {
            if (cities == null)
                throw new Exception("No cities found.");

            Console.WriteLine(new string('=', 20));
            Console.WriteLine(customMessage);
            Console.WriteLine(new string('=', 20));

            foreach (var city in cities)
            {
                Console.WriteLine($"Country: {city.Country.Name}");
                Console.WriteLine($"\tID: {city.ID.ToString().PadRight(20)} Name: {city.Name}.");
            }

            Console.WriteLine("\n\n");
        }
        #endregion

        #region Collections
        private static async Task SelectCollectionsAsync(int cityID, int? count = null)
        {
            var collections = await zomatoService.SelectCollectionsAsync(cityID, count);

            PrintCollectionResponse(collections, "Collections by city ID.");
        }
        private static async Task SelectCollectionsAsync(double latitude, double longitude, int? count = null)
        {
            var collections = await zomatoService.SelectCollectionsAsync(latitude, longitude, count);

            PrintCollectionResponse(collections, "Collections by latitude and longitude.");
        }

        private static void PrintCollectionResponse(Collections collections, string customMessage)
        {
            if (collections == null)
                throw new Exception("No collections found.");

            Console.WriteLine(new string('=', 20));
            Console.WriteLine(customMessage);
            Console.WriteLine(new string('=', 20));

            Console.WriteLine($"Share Url: {collections.ShareUrl}");
            Console.WriteLine(new string('-', 10));

            Console.WriteLine("\n\n");

            foreach (var collection in collections)
            {
                Console.WriteLine($"ID: {collection.ID.ToString()}");
                Console.WriteLine($"Title: {collection.Title}");
                Console.WriteLine($"Description: {collection.Description}");
                Console.WriteLine($"ImageUrl: {collection.ImageUrl}");
                Console.WriteLine($"Url: {collection.Url}");
                Console.WriteLine(new string('-', 10));
            }

            Console.WriteLine("\n\n");
        }
        #endregion

        #region Cuisines
        private static async Task SelectCuisinesAsync(int cityID, int? count = null)
        {
            var cuisines = await zomatoService.SelectCuisinesAsync(cityID, count);

            PrintCuisinesResponse(cuisines, "Cuisines by city ID.");
        }
        private static async Task SelectCuisinesAsync(double latitude, double longitude, int? count = null)
        {
            var cuisines = await zomatoService.SelectCuisinesAsync(latitude, longitude, count);

            PrintCuisinesResponse(cuisines, "Cuisines by latitude and longitude.");
        }

        private static void PrintCuisinesResponse(Cuisines cuisines, string customMessage)
        {
            if (cuisines == null)
                throw new Exception("No cuisines found.");

            Console.WriteLine(new string('=', 20));
            Console.WriteLine(customMessage);
            Console.WriteLine(new string('=', 20));

            foreach (var cuisine in cuisines)
                Console.WriteLine($"ID: {cuisine.ID}.\tName: {cuisine.Name}.");

            Console.WriteLine("\n\n");
        }
        #endregion

        #region Geocode
        private static async Task SelectGeocodeAsync(double latitude, double longitude)
        {
            var geocode = await zomatoService.SelectGeocodeAsync(latitude, longitude);

            PrintGeocodeResponse(geocode, "Popular Food & Nightlife Index around a location");
        }

        private static void PrintGeocodeResponse(Geocode geocode, string customMessage)
        {
            if(geocode == null)
                throw new Exception("No 'Geocode' information found");
            
            Console.WriteLine(new string('=', 20));
            Console.WriteLine(customMessage);
            Console.WriteLine(new string('=', 20));

            Console.WriteLine("Title: "+geocode.region.title);
            Console.WriteLine(geocode.region.cityName+", "+geocode.region.countryName);
            Console.WriteLine("Popularity:\t"+geocode.popularity.popularity);
            Console.WriteLine("Nightlife Index:\t"+geocode.popularity.nightlifeIndex);
            Console.WriteLine("Top cuisines:\t"+string.Join(", ",geocode.popularity.topCuisines.ToArray()));
            Console.WriteLine("link: "+geocode.link);
            Console.WriteLine(new string ('-',10));
            Console.WriteLine("Nearby restaurants");
            Console.WriteLine(new string ('-',10));

            foreach(var restaurant in geocode.nearbyRestaurantList) {
                Console.WriteLine(new string ('-',10));
                Console.WriteLine("Name:\t\t" + restaurant.name);
                Console.WriteLine("Cuisines:\t" + restaurant.cuisines);
                Console.WriteLine(
                        "Rating:\t\t" + restaurant.userRating.aggregateRating    + 
                        " / " + restaurant.userRating.ratingText                 +
                        " / out of " + restaurant.userRating.votes               + " votes"
                        );
                Console.WriteLine("Avg cost for 2:\t" + restaurant.currency + restaurant.averageCostForTwo);
                Console.WriteLine("Switch to order:\t" + (restaurant.switchToOrderMenu == 1 ? "yes" : "no"));
                Console.WriteLine("Online delivery:\t" + (restaurant.hasOnlineDelivery == 1 ? "yes" : "no"));
                Console.WriteLine("Delivering now:\t" + (restaurant.isDeliveringNow == 1 ? "yes" : "no"));
                Console.WriteLine("Table booking:\t" + (restaurant.hasTableBooking == 1 ? "yes" : "no"));
                Console.WriteLine("Address:\t" + restaurant.area.address);
                Console.WriteLine(new string ('-',10)+"\n");
            }
        }
        #endregion
    }
}