﻿using Newtonsoft.Json;

namespace Zomato.API.Domain
{
    internal sealed class LocationRootObject
    {
        #region Internal Properties
        [JsonProperty("location_suggestions")]
        internal ZomatoLocations Locations { get; set; }

        [JsonProperty("status")]
        internal string Status { get; set; }

        [JsonProperty("has_more")]
        internal int HasMore { get; set; }

        [JsonProperty("has_total")]
        internal int HasTotal { get; set; }
        #endregion

        #region Internal Methods
        internal Locations ToServiceObject()
        {
            var locations = new Locations();

            if (this.Locations.Count > 0)
            {
                foreach (var location in this.Locations)
                    locations.Add(location.ToServiceObject());
            }

            return locations;
        }
        #endregion
    }
}