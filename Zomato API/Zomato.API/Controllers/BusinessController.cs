namespace Zomato.API.Controllers
{
    internal sealed class BusinessController : BaseController
    {
        #region Internal Methods
        public override string GetUrl(string actionName)
        {
            return $"{actionName}";
        }
        #endregion
    }

    internal sealed class BusinessActions
    {
        #region Actions
        public const string SelectCategories = "categories";
        #endregion
    }
}