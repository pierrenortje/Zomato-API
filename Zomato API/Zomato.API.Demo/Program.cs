using System;
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
    ///         • GET /cities               [TBC]
    ///         • GET /collections          [TBC]
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
            await SelectCategories();
            await SelectCities("Cape Town");
        }

        private static async Task SelectCategories()
        {
            var categories = await zomatoService.SelectCategories();

            if (categories == null)
                throw new Exception("No categories found.");

            Console.WriteLine("Printing category names:");
            Console.WriteLine(new string('=', 20));

            foreach (var category in categories)
                Console.WriteLine($"ID: {category.ID}.\tName: {category.Name}.");
        }

        private static async Task SelectCities(string queryText)
        {
            var cities = await zomatoService.SelectCities(queryText);

            if (cities == null)
                throw new Exception("No cities found.");

            Console.WriteLine("Printing cities names:");
            Console.WriteLine(new string('=', 20));

            foreach (var city in cities)
                Console.WriteLine($"Country: {city.Country.Name.PadRight(10)}.\tID: {city.ID.ToString()}.\tName: {city.Name}.");
        }
        #endregion
    }
}