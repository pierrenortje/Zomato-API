using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zomato.API.Domain
{
    internal sealed class EstablishmentResponse
    {
        [JsonProperty("id")]
        internal int ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }
    }

    internal sealed class EstablishmentsResponse
    {
        [JsonProperty("establishment")]
        internal EstablishmentResponse Establishments { get; set; }
    }

    internal sealed class EstablishmentsRootObject
    {
        #region Internal Properties
        [JsonProperty("establishments")]
        internal List<EstablishmentsResponse> Establishments { get; set; }
        #endregion

        #region Internal Methods
        internal Establishments ToServiceObject()
        {
            var establishments = new Establishments();

            foreach (var establishment in this.Establishments)
                establishments.Add(new Establishment
                {
                    ID = establishment.Establishments.ID,
                    Name = establishment.Establishments.Name
                });

            return establishments;
        }
        #endregion
    }
}