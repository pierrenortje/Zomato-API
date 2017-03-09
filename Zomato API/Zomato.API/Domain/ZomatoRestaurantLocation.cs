using Newtonsoft.Json;

namespace Zomato.API.Domain
{
    internal sealed class ZomatoRestaurantLocation
    {
        #region Internal Properties
        [JsonProperty("address")]
        internal string Address { get; set; }

        [JsonProperty("locality")]
        internal string Locality { get; set; }

        [JsonProperty("city")]
        internal string CityName { get; set; }

        [JsonProperty("latitude")]
        internal string Latitude { get; set; }

        [JsonProperty("longitude")]
        internal string Longitude { get; set; }

        [JsonProperty("zipcode")]
        internal string ZipCode { get; set; }

        [JsonProperty("country_id")]
        internal string CountryID { get; set; }
        #endregion

        #region Internal Methods
        internal RestaurantLocation ToServiceObject()
        {
            var restaurantLocation = new RestaurantLocation
            {
                Address = this.Address,
                CityName = this.CityName,
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                ZipCode = this.ZipCode
            };

            return restaurantLocation;
        }
        #endregion
    }
}