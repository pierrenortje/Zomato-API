using System.Collections.Generic;

namespace Zomato.API.Domain
{
    public class Category
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }

    public class Categories : List<Category> { }
}