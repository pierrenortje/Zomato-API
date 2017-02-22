using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public class Collection
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }

    public class Collections : List<Collection> { }
}
