using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
    }

    public sealed class Cities : List<City> { }
}