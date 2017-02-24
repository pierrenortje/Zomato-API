using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class Establishment
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public sealed class Establishments : List<Establishment> { }
}