using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public sealed class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public sealed class Categories : List<Category> { }
}