using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class ZomatoLocation
    {
        #region Internal Properties
        [JsonProperty("entity_id")]
        internal int ID { get; set; }

        [JsonProperty("entity_type")]
        internal string Type { get; set; }

        [JsonProperty("title")]
        internal string Title { get; set; }

        [JsonProperty("latitude")]
        internal string Latitude { get; set; }

        [JsonProperty("longitude")]
        internal string Longitude { get; set; }

        [JsonProperty("city_id")]
        internal int CityID { get; set; }

        [JsonProperty("city_name")]
        internal string CityName { get; set; }

        [JsonProperty("country_id")]
        internal int CountryID { get; set; }

        [JsonProperty("country_name")]
        internal string CountryName { get; set; }
        #endregion

        #region Internal Methods
        internal Location ToServiceObject()
        {
            var location = new Location
            {
                ID = this.ID,
                Type = this.Type,
                City = new City
                {
                    ID = this.CityID,
                    Name = this.CityName,
                    Country = new Country
                    {
                        ID = this.CountryID,
                        Name = this.CountryName
                    }
                },
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Title = this.Title
            };

            return location;
        }
        #endregion
    }

    internal sealed class ZomatoLocations : List<ZomatoLocation> { }
}