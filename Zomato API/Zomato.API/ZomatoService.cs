using System.Threading.Tasks;
using Zomato.API.Domain;

namespace Zomato.API
{
    public sealed class ZomatoService
    {
        #region Private Fields
        private WebRequest webRequest = null;
        #endregion

        #region Constructor
        public ZomatoService()
        {
            webRequest = new WebRequest();
        }
        #endregion

        #region Public Async Methods
        /// <summary>
        /// Select a list of categories.
        /// </summary>
        /// <returns>A list of categories.</returns>
        public async Task<Categories> SelectCategoriesAsync()
        {
            Categories categories = null;
            CategoriesRootObject categoriesResponse = null;

            categoriesResponse = await webRequest.SelectCategoriesAsync();

            if (categoriesResponse?.Categories == null)
                return categories;

            categories = new Categories();

            foreach (var category in categoriesResponse.Categories)
                categories.Add(new Category
                {
                    ID = category.Categories.ID,
                    Name = category.Categories.Name
                });

            return categories;
        }

        /// <summary>
        /// Select a list of cities.
        /// </summary>
        /// <param name="queryText">The query text to search for.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of categories.</returns>
        public async Task<Cities> SelectCitiesAsync(string queryText, int? count = null)
        {
            return await SelectCitiesAsync(queryText, null, null, null, count);
        }
        /// <summary>
        /// Select a list of cities.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return</param>
        /// <returns>A list of categories.</returns>
        public async Task<Cities> SelectCitiesAsync(double latitude, double longitude, int? count = null)
        {
            return await SelectCitiesAsync(null, latitude, longitude, null, count);
        }
        /// <summary>
        /// Select a list of cities.
        /// </summary>
        /// <param name="cityIDs">A list of city IDs.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of categories.</returns>
        public async Task<Cities> SelectCitiesAsync(int[] cityIDs, int? count = null)
        {
            return await SelectCitiesAsync(null, null, null, cityIDs, count);
        }

        /// <summary>
        /// Select a collection of restaurants in a city.
        /// </summary>
        /// <param name="cityID">The city's ID.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of collections.</returns>
        public async Task<Collections> SelectCollectionsAsync(int cityID, int? count = null)
        {
            return await SelectCollectionsAsync(cityID, null, null, count);
        }
        /// <summary>
        /// Select a collection of restaurants by latitude and longitude.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of collections.</returns>
        public async Task<Collections> SelectCollectionsAsync(double latitude, double longitude, int? count = null)
        {
            return await SelectCollectionsAsync(null, latitude, longitude, count);
        }

        /// <summary>
        /// Select a list of cuisines in a city.
        /// </summary>
        /// <param name="cityID">The city's ID.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of cuisines.</returns>
        public async Task<Cuisines> SelectCuisinesAsync(int cityID, int? count = null)
        {
            return await SelectCuisinesAsync(cityID, null, null, count);
        }
        /// <summary>
        /// Select a list of cuisines by latitude and longitude.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of cuisines.</returns>
        public async Task<Cuisines> SelectCuisinesAsync(double latitude, double longitude, int? count = null)
        {
            return await SelectCuisinesAsync(null, latitude, longitude, count);
        }

        /// <summary>
        /// Select a list of establishments in a city.
        /// </summary>
        /// <param name="cityID">The city's ID.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of establishments.</returns>
        public async Task<Establishments> SelectEstablishmentsAsync(int cityID)
        {
            return await SelectEstablishmentsAsync(cityID, null, null);
        }
        /// <summary>
        /// Select a list of establishments by latitude and longitude.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="count">Max results to return.</param>
        /// <returns>A list of establishments.</returns>
        public async Task<Establishments> SelectEstablishmentsAsync(double latitude, double longitude)
        {
            return await SelectEstablishmentsAsync(null, latitude, longitude);
        }

        /// <summary>
        /// Get a food & nightlife index of given coordinates.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns>A list of popular cuisines and nearby restaurants around the given coordinates.</returns>
        public async Task<Geocode> SelectGeocodeAsync(double latitude, double longitude)
        {
            return await SelectGeocodeAsync(null, latitude, longitude, null);
        }

        /// <summary>
        /// Get Foodie Index, Nightlife Index, Top Cuisines and Best rated restaurants in a given location
        /// </summary>
        /// <param name="locationID">ID of the location</param>
        /// <param name="entityType">Name of the entity</param>
        /// <returns></returns>
        public async Task<LocationDetails> SelectLocationDetailsAsync(int locationID, string entityType)
        {
            return await SelectLocationDetailsAsyncP(locationID, entityType);
        }

        /// <summary>
        /// Get the daily menu by restaurant ID.
        /// </summary>
        /// <param name="restaurantID">The restaurant's ID.</param>
        /// <returns>The daily menu.</returns>
        public async Task<DailyMenus> GetDailyMenuAsync(int restaurantID)
        {
            DailyMenus dailyMenus = null;
            DailyMenuRootObject dailyMenuResponse = null;

            dailyMenuResponse = await webRequest.GetDailyMenuAsync(restaurantID);

            if (dailyMenuResponse == null)
                return dailyMenus;

            dailyMenus = new DailyMenus();

            foreach (var dailyMenu in dailyMenuResponse.DailyMenus)
            {
                var dailyMenuItem = new DailyMenu
                {
                    ID = dailyMenu.ID,
                    Name = dailyMenu.Name,
                    StartDate = dailyMenu.StartDate,
                    EndDate = dailyMenu.EndDate
                };

                foreach (var dish in dailyMenu.Dishes)
                    dailyMenuItem.Dishes.Add(new Dish
                    {
                        ID = dish.ID,
                        Name = dish.Name,
                        Price = dish.Price
                    });

                dailyMenus.Add(dailyMenuItem);
            }

            return dailyMenus;
        }

        /// <summary>
        /// Get a restaurant by its ID. Partner Access is required to access photos and reviews.
        /// </summary>
        /// <param name="restaurantID">The restaurant's ID.</param>
        /// <returns>A restaurant.</returns>
        public async Task<Restaurant> GetRestaurantAsync(int restaurantID)
        {
            Restaurant restaurant = null;
            ZomatoRestaurant restaurantResponse = null;

            restaurantResponse = await webRequest.GetRestaurantAsync(restaurantID);

            if (restaurantResponse == null)
                return restaurant;

            #region Photos
            var photos = new Photos();
            if (restaurantResponse.Photos != null)
                foreach (var photo in restaurantResponse.Photos)
                    photos.Add(new Photo
                    {
                        ID = photo.ID,
                        Url = photo.Url,
                        ThumbUrl = photo.ThumbUrl,
                        Caption = photo.Caption,
                        Height = photo.Height,
                        Width = photo.Width,
                        Timestamp = photo.Timestamp,
                        RestaurantID = photo.RestaurantID,
                        TotalComments = photo.TotalComments,
                        User = new User
                        {
                            Name = photo.User.Name,
                            ProfileImageUrl = photo.User.ProfileImageUrl,
                            ProfileUrl = photo.User.ProfileUrl,
                            ZomatoHandle = photo.User.ZomatoHandle,
                            FoodieLevel = photo.User.FoodieLevel,
                            FoodieLevelNumber = photo.User.FoodieLevelNumber
                        },
                        LikesCount = photo.LikesCount
                    });
            #endregion

            #region Reviews
            var reviews = new Reviews();
            if (restaurantResponse.Reviews != null)
                foreach (var review in restaurantResponse.Reviews)
                    reviews.Add(new Review
                    {
                        ID = review.ID,
                        Likes = review.Likes,
                        Rating = review.Rating,
                        RatingText = review.RatingText,
                        ReviewText = review.ReviewText,
                        Timestamp = review.Timestamp,
                        TotalComments = review.TotalComments,
                        User = new User
                        {
                            Name = review.User.Name,
                            ProfileImageUrl = review.User.ProfileImageUrl,
                            ProfileUrl = review.User.ProfileUrl,
                            ZomatoHandle = review.User.ZomatoHandle,
                            FoodieLevel = review.User.FoodieLevel,
                            FoodieLevelNumber = review.User.FoodieLevelNumber
                        }
                    });
            #endregion

            #region Restaurant
            restaurant = new Restaurant
            {
                ID = restaurantResponse.ID,
                Name = restaurantResponse.Name,
                Url = restaurantResponse.Url,
                EventsUrl = restaurantResponse.EventsUrl,
                MenuUrl = restaurantResponse.MenuUrl,
                PhotosUrl = restaurantResponse.PhotosUrl,
                ThumbUrl = restaurantResponse.ThumbUrl,
                Cuisines = restaurantResponse.Cuisines,
                PriceRange = restaurantResponse.PriceRange,
                AverageCostForTwo = restaurantResponse.AverageCostForTwo,
                FeaturedImageUrl = restaurantResponse.FeaturedImageUrl,
                PhoneNumbers = restaurantResponse.PhoneNumbers,
                Location = new RestaurantLocation
                {
                    Address = restaurantResponse.Location.Address,
                    CityName = restaurantResponse.Location.CityName,
                    Latitude = restaurantResponse.Location.Latitude,
                    Longitude = restaurantResponse.Location.Longitude,
                    ZipCode = restaurantResponse.Location.ZipCode
                },
                Photos = photos,
                TotalPhotos = restaurantResponse.TotalPhotos,
                Reviews = reviews
            };
            #endregion

            return restaurant;
        }
        #endregion

        #region Private Async Methods
        private async Task<Cities> SelectCitiesAsync(string queryText, double? latitude, double? longitude, int[] cityIDs, int? count)
        {
            Cities cities = null;
            CitiesRootObject citiesResponse = null;

            citiesResponse = await webRequest.SelectCitiesAsync(queryText, latitude, longitude, cityIDs, count);

            if (citiesResponse?.LocationSuggestions == null)
                return cities;

            cities = new Cities();

            foreach (var city in citiesResponse.LocationSuggestions)
            {
                var country = new Country
                {
                    ID = city.CountryID,
                    Name = city.CountryName
                };

                cities.Add(new City
                {
                    ID = city.ID,
                    Name = city.Name,
                    Country = country
                });
            }

            return cities;
        }

        private async Task<Collections> SelectCollectionsAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            Collections collections = null;
            CollectionsRootObject collectionResponse = null;

            collectionResponse = await webRequest.SelectCollectionsAsync(cityID, latitude, longitude, count);

            if (collectionResponse?.Collections == null)
                return collections;

            collections = new Collections();

            foreach (var restaurant in collectionResponse.Collections)
            {
                collections.Add(new Collection
                {
                    ID = restaurant.Collections.ID,
                    Title = restaurant.Collections.Title,
                    Url = restaurant.Collections.Url,
                    Description = restaurant.Collections.Description
                });
            }

            collections.ShareUrl = collectionResponse.ShareUrl;

            return collections;
        }

        private async Task<Cuisines> SelectCuisinesAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            Cuisines cuisines = null;
            CuisinesRootObject cuisinesResponse = null;

            cuisinesResponse = await webRequest.SelectCuisinesAsync(cityID, latitude, longitude, count);

            if (cuisinesResponse?.Cuisines == null)
                return cuisines;

            cuisines = new Cuisines();

            foreach (var cuisine in cuisinesResponse.Cuisines)
                cuisines.Add(new Cuisine
                {
                    ID = cuisine.Cuisines.ID,
                    Name = cuisine.Cuisines.Name
                });

            return cuisines;
        }

        private async Task<Establishments> SelectEstablishmentsAsync(int? cityID, double? latitude, double? longitude)
        {
            Establishments establishments = null;
            EstablishmentsRootObject establishmentsResponse = null;

            establishmentsResponse = await webRequest.SelectEstablishmentsAsync(cityID, latitude, longitude);

            if (establishmentsResponse?.Establishments == null)
                return establishments;

            establishments = new Establishments();

            foreach (var establishment in establishmentsResponse.Establishments)
                establishments.Add(new Establishment
                {
                    ID = establishment.Establishments.ID,
                    Name = establishment.Establishments.Name
                });

            return establishments;
        }

        private async Task<Geocode> SelectGeocodeAsync(int? cityID, double? latitude, double? longitude, int? count)
        {
            Geocode geocode = null;
            GeocodeRootObject geocodeResponse = null;

            geocodeResponse = await webRequest.SelectGeocodeAsync(latitude, longitude);

            if (geocodeResponse == null)
                return geocode;

            geocode = new Geocode
            {
                Location = new Location
                {
                    City = new City
                    {
                        ID = geocodeResponse.Location.CityID,
                        Name = geocodeResponse.Location.CityName,
                        Country = new Country
                        {
                            ID = geocodeResponse.Location.CountryID,
                            Name = geocodeResponse.Location.CountryName
                        }
                    },
                    Latitude = geocodeResponse.Location.Latitude,
                    Longitude = geocodeResponse.Location.Longitude,
                    Title = geocodeResponse.Location.Title
                },
                Link = geocodeResponse.Link,
                Popularity = new Popularity
                {
                    City = new City
                    {
                        Name = geocodeResponse.Popularity.CityName
                    },
                    SubZone = new SubZone
                    {
                        ID = geocodeResponse.Popularity.SubZoneID,
                        Name = geocodeResponse.Popularity.SubZoneName
                    },
                    NearbyRestaurantIDs = geocodeResponse.Popularity.NearbyRestaurantIDs,
                    NightlifeIndex = geocodeResponse.Popularity.NightlifeIndex,
                    NightlifeRestaurants = geocodeResponse.Popularity.NightlifeRestaurants,
                    PopularityRating = geocodeResponse.Popularity.PopularityRating,
                    TopCuisines = geocodeResponse.Popularity.TopCuisines,
                    TotalPopularityRestaurants = geocodeResponse.Popularity.TotalPopularityRestaurants
                },
                NearbyRestaurantList = new NearbyRestaurantList()
            };

            foreach(var zomatoRestaurant in geocodeResponse.Restaurants) {
                geocode.NearbyRestaurantList.Add(ZomatoConverter.ConvertRestaurant(zomatoRestaurant.Restaurants));
            }

            #region Pierre_code_backup
            /*
            #region Nearby Restaurants
            foreach (var restaurant in geocodeResponse.Restaurants)
            {
                #region Photos
                var photos = new Photos();
                if (restaurant.Restaurants.Photos != null)
                    foreach (var photo in restaurant.Restaurants.Photos)
                        photos.Add(new Photo
                        {
                            ID = photo.ID,
                            Caption = photo.Caption,
                            Height = photo.Height,
                            Width = photo.Width,
                            LikesCount = photo.LikesCount,
                            RestaurantID = photo.RestaurantID,
                            ThumbUrl = photo.ThumbUrl,
                            Timestamp = photo.Timestamp,
                            TotalComments = photo.TotalComments,
                            Url = photo.Url,
                            User = new User
                            {
                                Name = photo.User.Name,
                                FoodieLevel = photo.User.FoodieLevel,
                                FoodieLevelNumber = photo.User.FoodieLevelNumber,
                                ProfileImageUrl = photo.User.ProfileImageUrl,
                                ProfileUrl = photo.User.ProfileUrl,
                                ZomatoHandle = photo.User.ZomatoHandle
                            }
                        });
                #endregion

                #region Reviews
                var reviews = new Reviews();
                if (restaurant.Restaurants.Reviews != null)
                    foreach (var review in restaurant.Restaurants.Reviews)
                    reviews.Add(new Review
                    {
                        ID = review.ID,
                        Likes = review.Likes,
                        Rating = review.Rating,
                        RatingText = review.RatingText,
                        ReviewText = review.RatingText,
                        Timestamp = review.Timestamp,
                        TotalComments = review.TotalComments,
                        User = new User
                        {
                            Name = review.User.Name,
                            FoodieLevel = review.User.FoodieLevel,
                            FoodieLevelNumber = review.User.FoodieLevelNumber,
                            ProfileImageUrl = review.User.ProfileImageUrl,
                            ProfileUrl = review.User.ProfileUrl,
                            ZomatoHandle = review.User.ZomatoHandle
                        }
                    });
                #endregion

                geocode.NearbyRestaurantList.Add(new Restaurant
                {
                    ID = restaurant.Restaurants.ID,
                    Name = restaurant.Restaurants.Name,
                    AverageCostForTwo = restaurant.Restaurants.AverageCostForTwo,
                    Cuisines = restaurant.Restaurants.Cuisines,
                    EventsUrl = restaurant.Restaurants.EventsUrl,
                    FeaturedImageUrl = restaurant.Restaurants.FeaturedImageUrl,
                    Location = new RestaurantLocation
                    {
                        Address = restaurant.Restaurants.Location.Address,
                        CityName = restaurant.Restaurants.Location.CityName,
                        Latitude = restaurant.Restaurants.Location.Latitude,
                        Longitude = restaurant.Restaurants.Location.Longitude,
                        ZipCode = restaurant.Restaurants.Location.ZipCode
                    },
                    MenuUrl = restaurant.Restaurants.MenuUrl,
                    PhoneNumbers = restaurant.Restaurants.PhoneNumbers,
                    Photos = photos,
                    PhotosUrl = restaurant.Restaurants.PhotosUrl,
                    PriceRange = restaurant.Restaurants.PriceRange,
                    Reviews = reviews,
                    ThumbUrl = restaurant.Restaurants.ThumbUrl,
                    TotalPhotos = restaurant.Restaurants.TotalPhotos,
                    Url = restaurant.Restaurants.Url
                });

            }
            #endregion
            */
            #endregion

            return geocode;
        }

        private async Task<LocationDetails> SelectLocationDetailsAsyncP(int? locationID, string entityType)
        {
            LocationDetails locationDetails = null;
            LocationDetailsRootObject locationDetailsResponse = null;

            locationDetailsResponse = await webRequest.SelectLocationDetails(locationID, entityType);

            if(locationDetailsResponse == null)
                return locationDetails;

            locationDetails = new LocationDetails
            {
                Location = new Location
                {
                    EntityType = locationDetailsResponse.Location.EntityType,                    
                    Longitude = locationDetailsResponse.Location.Longitude,
                    Latitude = locationDetailsResponse.Location.Latitude,
                    Title = locationDetailsResponse.Location.Title,
                    City = new City
                    {
                        ID = locationDetailsResponse.Location.CityID,
                        Name = locationDetailsResponse.Location.CityName,
                        Country = new Country
                        {
                            Name = locationDetailsResponse.Location.CountryName
                        }
                    }
                },

                Popularity = new Popularity
                {                    
                    PopularityRating = locationDetailsResponse.Popularity,
                    NightlifeIndex = locationDetailsResponse.NightLifeIndex,
                    NearbyRestaurantIDs = locationDetailsResponse.NearbyRes,
                    TopCuisines = locationDetailsResponse.TopCuisines                 
                },

                RestaurantCount = locationDetailsResponse.RestaurantCount,

                BestRatedRestaurantList = new BestRatedRestaurantList()

            };

            foreach(var zomatoRestaurant in locationDetailsResponse.Restaurants) {
                locationDetails.BestRatedRestaurantList.Add(ZomatoConverter.ConvertRestaurant(zomatoRestaurant.Restaurant));
            }

            return locationDetails;
        }
        #endregion      

    }
}