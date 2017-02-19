namespace Zomato.API.Controllers
{
    internal abstract class BaseController
    {
        internal string GetUrl(string actionName)
        {
            return $"{actionName}";
        }
    }
}