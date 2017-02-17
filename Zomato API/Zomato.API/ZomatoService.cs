using System;
using System.Threading.Tasks;
using Zomato.API.Domain;

namespace Zomato.API
{
    public sealed class ZomatoService : IDisposable
    {
        #region Private Fields
        private WebRequest webRequest = null;
        #endregion

        #region Constructor
        public ZomatoService()
        {
            webRequest = new WebRequest();
        }
        #endregion

        #region Public Async Methods
        /// <summary>
        /// Get a list of categories.
        /// </summary>
        /// <returns></returns>
        public async Task<Categories> SelectCategories()
        {
            Categories categories = null;
            CategoriesResponse categoriesResponse = null;

            categoriesResponse = await webRequest.SelectCategories();

            if (categoriesResponse != null)
            {
                categories = new Categories();

                foreach (var category in categoriesResponse)
                    categories.Add(new Category { ID = category.ID, Name = category.Name });
            }

            return categories;
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            if (webRequest != null)
            {
                webRequest = null;
            }
        }
        #endregion
    }
}