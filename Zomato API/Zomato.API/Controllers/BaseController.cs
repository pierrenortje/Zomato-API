namespace Zomato.API.Controllers
{
    internal abstract class BaseController
    {
        public abstract string GetUrl(string actionName);
    }
}