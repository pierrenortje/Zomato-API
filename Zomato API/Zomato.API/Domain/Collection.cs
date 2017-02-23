using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class Collection
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

    public sealed class Collections : List<Collection>
    {
        public string ShareUrl { get; set; }
    }
}