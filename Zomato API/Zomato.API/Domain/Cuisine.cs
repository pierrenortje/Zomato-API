using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class Cuisine
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public sealed class Cuisines : List<Cuisine> { }
}