using System;
using System.Threading.Tasks;
using Zomato.API.Domain;

/*
 * TODO: 2017-03-09 - pierre.nortje - Need to add non-async support.
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
    ///         • GET /categories
    ///         • GET /cities
    ///         • GET /collections
    ///         • GET /cuisines
    ///         • GET /establishments
    ///         • GET /geocode
    ///         
    ///     LocationController:
    ///         • GET /location_details
    ///         • GET /locations
    ///         
    ///     RestaurantController:
    ///         • GET /dailymenu
    ///         • GET /restaurant
    ///         • GET /reviews
    ///         • GET /search
    ///         
    /// </summary>
    class Program
    {
        #region Private Static Fields
        private static ZomatoService zomatoService = new ZomatoService();

        private static int cityID = 64;
        private static int[] cityIDs = new int[] { cityID };

        private static int restaurantID = 18361256;

        private static string cityName = "Cape Town";
        private static string restaurantName = "Rocomamas";

        private static double longitude = -33.9249;
        private static double latitude = 18.4241;

        private static Random random = new Random();
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
            try
            {
                //await SelectCategoriesAsync();

                //await SelectCitiesAsync(cityName);
                //await SelectCitiesAsync(cityName, 5);
                //await SelectCitiesAsync(longitude, latitude);
                //await SelectCitiesAsync(cityIDs);

                //await SelectCollectionsAsync(cityID);

                //await SelectCuisinesAsync(cityID);
                //await SelectCuisinesAsync(longitude, latitude);

                //await SelectEstablishmentsAsync(cityID);
                //await SelectEstablishmentsAsync(longitude, latitude);

                //await GetRestaurantAsync(restaurantID);

                //await GetDailyMenuAsync(restaurantID);

                //await SelectGeocodeAsync(longitude, latitude);

                //await SelectLocationDetailsAsync(cityID, LocationType.City);

                //await SearchLocationAsync(cityName);

                //await SelectReviewsAsync(restaurantID, null, null);

                await SearchAsync(restaurantName);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadLine();
            }
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

        #region Establishments
        private static async Task SelectEstablishmentsAsync(int cityID)
        {
            var establishments = await zomatoService.SelectEstablishmentsAsync(cityID);

            PrintEstablishmentsResponse(establishments, "Establishments by city ID.");
        }
        private static async Task SelectEstablishmentsAsync(double latitude, double longitude)
        {
            var establishments = await zomatoService.SelectEstablishmentsAsync(latitude, longitude);

            PrintEstablishmentsResponse(establishments, "Establishments by latitude and longitude.");
        }

        private static void PrintEstablishmentsResponse(Establishments establishments, string customMessage)
        {
            if (establishments == null)
                throw new Exception("No establishments found.");

            Console.WriteLine(new string('=', 20));
            Console.WriteLine(customMessage);
            Console.WriteLine(new string('=', 20));

            foreach (var establishment in establishments)
                Console.WriteLine($"ID: {establishment.ID}.\tName: {establishment.Name}.");

            Console.WriteLine("\n\n");
        }
        #endregion

        #region Restaurant
        private static async Task GetRestaurantAsync(int restaurantID)
        {
            var restaurant = await zomatoService.GetRestaurantAsync(restaurantID);

            if (restaurant == null)
                throw new Exception("No restaurant found.");

            PrintRestaurant(restaurant);

            Console.WriteLine("\n\n");
        }
        #endregion

        #region Daily Menu
        private static async Task GetDailyMenuAsync(int restaurantID)
        {
            var dailyMenus = await zomatoService.GetDailyMenuAsync(restaurantID);

            if (dailyMenus == null)
                throw new Exception("No daily menu found.");

            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Daily menu by restaurant ID.");
            Console.WriteLine(new string('=', 20));

            foreach (var dailyMenu in dailyMenus)
            {
                Console.WriteLine($"ID: {dailyMenu.ID}.");
                Console.WriteLine($"Name: {dailyMenu.Name}.");
                Console.WriteLine($"Start Date: {dailyMenu.StartDate}.");
                Console.WriteLine($"End Date: {dailyMenu.EndDate}.");

                foreach (var dish in dailyMenu.Dishes)
                {
                    Console.WriteLine($"\t Dish - ID: {dish.ID}.");
                    Console.WriteLine($"\t Dish - Name: {dish.Name}.");
                    Console.WriteLine($"\t Dish - Price: {dish.Price}.");
                }
            }

            Console.WriteLine("\n\n");
        }
        #endregion

        #region Geocode
        private static async Task SelectGeocodeAsync(double latitude, double longitude)
        {
            var geocode = await zomatoService.SelectGeocodeAsync(latitude, longitude);

            if (geocode == null)
                throw new Exception("No geocode information found.");

            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Popular Food & Nightlife Index around a location.");
            Console.WriteLine(new string('=', 20));

            Console.WriteLine($"Link: " + geocode.Link);
            PrintPopularity(geocode.Popularity);

            foreach (var restaurant in geocode.NearbyRestaurantList)
                PrintRestaurant(restaurant);
        }
        #endregion

        #region Location Details
        private static async Task SelectLocationDetailsAsync(int locationID, string entityType)
        {
            var locationDetails = await zomatoService.SelectLocationDetailsAsync(locationID, entityType);

            if (locationDetails == null)
                throw new Exception("No location detail information found.");

            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Foodie Index, Nightlife Index, Top Cuisines and Best rated restaurants in a given location.");
            Console.WriteLine(new string('=', 20));

            PrintLocation(locationDetails.Location);
            PrintPopularity(locationDetails.Popularity);

            Console.WriteLine("\nBest rated restaurants:");

            foreach (var restaurant in locationDetails.BestRatedRestaurantList)
                PrintRestaurant(restaurant);
        }
        #endregion

        #region Locations
        private static async Task SearchLocationAsync(string queryText)
        {
            var locations = await zomatoService.SearchLocationAsync(queryText);

            if (locations == null)
                throw new Exception("No location information found.");

            Console.WriteLine(new string('=', 20));
            Console.WriteLine("A list of locations.");
            Console.WriteLine(new string('=', 20));

            foreach (var location in locations)
                PrintLocation(location);

            Console.WriteLine("\n\n");
        }
        #endregion

        #region Reviews
        private static async Task SelectReviewsAsync(int restaurantID, int? start, int? count)
        {
            var reviews = await zomatoService.SelectReviewsAsync(restaurantID, start, count);

            if (reviews == null)
                throw new Exception("No reviews found.");

            Console.WriteLine(new string('=', 20));
            Console.WriteLine("A list of reviews:");
            Console.WriteLine(new string('=', 20));

            Console.WriteLine($"Reviews amount: {reviews.ReviewsCount}");
            Console.WriteLine($"Reviews start: {reviews.ReviewsCount}");
            Console.WriteLine($"Reviews shown: {reviews.ReviewsShown}");

            Console.WriteLine(new string('=', 20));

            foreach (var review in reviews.Reviews)
            {
                PrintReview(review);

                PrintUser(review.User);
            }
        }
        #endregion

        #region Search
        private static async Task SearchAsync(string queryText, double? longitude = null, double? latitude = null, double? radius = null, int? start = null, int? count = null, string sort = null, string order = null)
        {
            var searchResults = await zomatoService.SearchByKeywordAsync(queryText);

            if (searchResults == null)
                throw new Exception("No search results found.");

            foreach (var restaurant in searchResults.Restaurants)
            {
                Console.ForegroundColor = GetRandomColour();
                PrintRestaurant(restaurant);
            }
        }
        #endregion

        #region Print Entities
        private static void PrintRestaurant(Restaurant restaurant)
        {
            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Restaurant by ID.");
            Console.WriteLine(new string('=', 20));

            Console.WriteLine($"ID: {restaurant.ID}.");
            Console.WriteLine($"Name: {restaurant.Name}.");
            Console.WriteLine($"Url: {restaurant.Url}.");
            Console.WriteLine($"Events Url: {restaurant.EventsUrl}.");
            Console.WriteLine($"Menu Url: {restaurant.MenuUrl}.");
            Console.WriteLine($"Photos Url: {restaurant.PhotosUrl}.");
            Console.WriteLine($"Thumb Url: {restaurant.ThumbUrl}.");

            if (restaurant.Cuisines != null)
                foreach (var cuisine in restaurant.Cuisines)
                    Console.WriteLine($"Cuisine: {cuisine}.");

            Console.WriteLine($"Price Range: {restaurant.PriceRange}.");
            Console.WriteLine($"Average Cost For Two: {restaurant.AverageCostForTwo}.");
            Console.WriteLine($"Featured Image Url: {restaurant.FeaturedImageUrl}.");

            if (restaurant.PhoneNumbers != null)
                foreach (var number in restaurant.PhoneNumbers)
                    Console.WriteLine($"Phone Number: {number}.");

            PrintRestaurantLocation(restaurant.Location);

            #region Photos
            if (restaurant.Photos != null)
                foreach (var photo in restaurant.Photos)
                    PrintPhoto(photo);
            #endregion

            Console.WriteLine($"TotalPhotos: {restaurant.TotalPhotos}.");

            #region Reviews
            if (restaurant.Reviews != null)
                foreach (var review in restaurant.Reviews)
                    PrintReview(review);
            #endregion
        }
        private static void PrintReview(Review review)
        {
            Console.WriteLine($"Review - ID: {review.ID}.");
            Console.WriteLine($"Review - Likes: {review.Likes}.");
            Console.WriteLine($"Review - Rating: {review.Rating}.");
            Console.WriteLine($"Review - Rating Text: {review.RatingText}.");
            Console.WriteLine($"Review - Review Text: {review.ReviewText}.");
            Console.WriteLine($"Review - Timestamp: {review.Timestamp}.");
            Console.WriteLine($"Review - Total Comments: {review.TotalComments}.");

            PrintUser(review.User);
        }
        private static void PrintUser(User user)
        {
            Console.WriteLine($"User - Name: {user.Name}.");
            Console.WriteLine($"User - Profile Image Url: {user.ProfileImageUrl}.");
            Console.WriteLine($"User - Profile Url: {user.ProfileUrl}.");
            Console.WriteLine($"User - Zomato Handle: {user.ZomatoHandle}.");
            Console.WriteLine($"User - Foodie Level: {user.FoodieLevel}.");
            Console.WriteLine($"User - Foodie Level Number: {user.FoodieLevelNumber}.");
        }
        private static void PrintPhoto(Photo photo)
        {
            Console.WriteLine($"Photo - ID: {photo.ID}.");
            Console.WriteLine($"Photo - Url: {photo.Url}.");
            Console.WriteLine($"Photo - Thumb Url: {photo.ThumbUrl}.");
            Console.WriteLine($"Photo - Caption: {photo.Caption}.");
            Console.WriteLine($"Photo - Height: {photo.Height}.");
            Console.WriteLine($"Photo - Width: {photo.Width}.");
            Console.WriteLine($"Photo - Timestamp: {photo.Timestamp}.");
            Console.WriteLine($"Photo - Restaurant ID: {photo.RestaurantID}.");
            Console.WriteLine($"Photo - Total Comments: {photo.TotalComments}.");

            PrintUser(photo.User);
        }
        private static void PrintRestaurantLocation(RestaurantLocation restaurantLocation)
        {
            Console.WriteLine($"Restaurant Location - Address: {restaurantLocation.Address}.");
            Console.WriteLine($"Restaurant Location - City: {restaurantLocation.CityName}.");
            Console.WriteLine($"Restaurant Location - Latitude: {restaurantLocation.Latitude}.");
            Console.WriteLine($"Restaurant Location - Longitude: {restaurantLocation.Longitude}.");
            Console.WriteLine($"Restaurant Location - Zip Code: {restaurantLocation.ZipCode}.");
        }
        private static void PrintLocation(Location location)
        {
            Console.WriteLine($"Location - Title: {location.Title}.");
            Console.WriteLine($"Location - Longitude: {location.Longitude}.");
            Console.WriteLine($"Location - Latitude: {location.Latitude}.");
            Console.WriteLine($"Location - City ID: {location.City.ID}.");
            Console.WriteLine($"Location - City Name: {location.City.Name}.");
            Console.WriteLine($"Location - Country ID: {location.City.Country.ID}.");
            Console.WriteLine($"Location - Country Name: {location.City.Country.Name}.");
        }
        private static void PrintPopularity(Popularity popularity)
        {
            Console.WriteLine($"Popularity - Country ID: " + popularity.City?.Country?.ID);
            Console.WriteLine($"Popularity - Country Name: " + popularity.City?.Country?.Name);
            Console.WriteLine($"Popularity - City ID: " + popularity.City.ID);
            Console.WriteLine($"Popularity - City Name: " + popularity.City.Name);
            Console.WriteLine($"Popularity - Subzone ID: " + popularity.Subzone.ID);
            Console.WriteLine($"Popularity - Subzone Name: " + popularity.Subzone.Name);
            Console.WriteLine($"Popularity - Nearby Restaurant IDs: " + popularity.NearbyRestaurantIDs);
            Console.WriteLine($"Popularity - Nightlife Index: " + popularity.NightlifeIndex);
            Console.WriteLine($"Popularity - Nightlife Restaurants: " + popularity.NightlifeRestaurants);
            Console.WriteLine($"Popularity - PopularityRating: " + popularity.PopularityRating);
            Console.WriteLine($"Popularity - Top Cuisines: " + popularity.TopCuisines);
            Console.WriteLine($"Popularity - Total Popularity Restaurants: " + popularity.TotalPopularityRestaurants);
        }
        #endregion

        #region Utilies
        private static ConsoleColor GetRandomColour()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(random.Next(consoleColors.Length));
        }
        #endregion
    }
}