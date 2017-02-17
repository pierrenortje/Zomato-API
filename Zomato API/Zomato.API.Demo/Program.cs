using System;
using System.Threading.Tasks;

namespace Zomato.API.Demo
{
    /// <summary>
    /// View documentation at: https://developers.zomato.com/documentation
    /// </summary>
    class Program
    {
        #region Private Static Fields
        private static ZomatoService zomatoService = new ZomatoService();
        #endregion

        #region Public Static Methods
        public static void Main(string[] args)
        {
            Task.Run(() => MainAsync());

            Console.ReadLine();
        }
        #endregion

        #region Private Static Methods
        private static async void MainAsync()
        {
            var categories = await zomatoService.SelectCategories();
        }
        #endregion
    }
}