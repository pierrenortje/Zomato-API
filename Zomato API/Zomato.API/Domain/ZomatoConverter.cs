using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zomato.API.Domain
{
    public class ZomatoConverter
    {     
        /// <summary>
        /// Converts a ZomatoRestaurant object into a Restaurant object
        /// </summary>
        /// <param name="zomatoRestaurant">The populated ZomatoRestaurant object</param>
        /// <param name="restaurant">The empty Restaurant object</param>
        /// <returns></returns>
        public static Restaurant ConvertRestaurant(ZomatoRestaurant zomatoRestaurant, Restaurant restaurant)
        {
            Restaurant newRestaurant = new Restaurant();

            newRestaurant.ID = zomatoRestaurant.ID;
            newRestaurant.Name = zomatoRestaurant.Name;
            newRestaurant.AverageCostForTwo = zomatoRestaurant.AverageCostForTwo;
            newRestaurant.Cuisines = zomatoRestaurant.Cuisines;
            newRestaurant.EventsUrl = zomatoRestaurant.EventsUrl;
            newRestaurant.FeaturedImageUrl = zomatoRestaurant.FeaturedImageUrl;
            newRestaurant.Location = new RestaurantLocation
            {
                Address = zomatoRestaurant.Location.Address,
                CityName = zomatoRestaurant.Location.CityName,
                Latitude = zomatoRestaurant.Location.Latitude,
                Longitude = zomatoRestaurant.Location.Longitude,
                ZipCode = zomatoRestaurant.Location.ZipCode
            };
            newRestaurant.MenuUrl = zomatoRestaurant.MenuUrl;
            newRestaurant.PhoneNumbers = zomatoRestaurant.PhoneNumbers;
            
            if (zomatoRestaurant.Photos != null) {
                foreach (var photo in zomatoRestaurant.Photos)
                    newRestaurant.Photos.Add(new Photo
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
            }

            newRestaurant.PhotosUrl = zomatoRestaurant.PhotosUrl;
            newRestaurant.PriceRange = zomatoRestaurant.PriceRange;

            if (zomatoRestaurant.Reviews != null) {
                    foreach (var review in zomatoRestaurant.Reviews)
                    newRestaurant.Reviews.Add(new Review
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
            }

            newRestaurant.ThumbUrl = zomatoRestaurant.ThumbUrl;
            newRestaurant.TotalPhotos = zomatoRestaurant.TotalPhotos;
            newRestaurant.Url = zomatoRestaurant.Url;

            return newRestaurant;
        }    

    }
}
