using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class CollectionResponse
    {
        [JsonProperty("collection_id")]
        internal int ID { get; set; }

        /// <summary>
        /// Number of restaurants in the collection.
        /// </summary>
        [JsonProperty("res_count")]
        internal int TotalRestaurants { get; set; }

        [JsonProperty("image_url")]
        internal string ImageUrl { get; set; }

        [JsonProperty("url")]
        internal string Url { get; set; }

        [JsonProperty("title")]
        internal string Title { get; set; }

        [JsonProperty("description")]
        internal string Description { get; set; }

        [JsonProperty("share_url")]
        internal string ShareUrl { get; set; }
    }

    internal sealed class CollectionsResponse
    {
        [JsonProperty("collection")]
        internal CollectionResponse Collections { get; set; }
    }

    internal sealed class CollectionsRootObject
    {
        #region Internal Properties
        [JsonProperty("collections")]
        internal List<CollectionsResponse> Collections { get; set; }

        [JsonProperty("has_more")]
        internal int HasMore { get; set; }

        [JsonProperty("share_url")]
        internal string ShareUrl { get; set; }

        [JsonProperty("display_text")]
        internal string DisplayText { get; set; }

        [JsonProperty("has_total")]
        internal int HasTotal { get; set; }
        #endregion

        #region Internal Methods
        internal Collections ToServiceObject()
        {
            var collections = new Collections();

            foreach (var restaurant in this.Collections)
                collections.Add(new Collection
                {
                    ID = restaurant.Collections.ID,
                    Title = restaurant.Collections.Title,
                    Url = restaurant.Collections.Url,
                    Description = restaurant.Collections.Description
                });

            collections.ShareUrl = this.ShareUrl;

            return collections;
        }
        #endregion
    }
}