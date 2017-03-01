using System.Threading.Tasks;
using Zomato.API.Domain;

namespace Zomato.API
{
    public sealed partial class ZomatoService
    {
        #region Public Async Methods
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
    }
}