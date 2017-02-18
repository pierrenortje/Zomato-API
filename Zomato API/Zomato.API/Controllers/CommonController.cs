namespace Zomato.API.Controllers
{
    internal sealed class CommonController : BaseController
    {
        #region Internal Methods
        public override string GetUrl(string actionName)
        {
            return $"{actionName}";
        }
        #endregion
    }

    internal sealed class CommonActions
    {
        #region Actions
        public const string SelectCategories = "categories";
        #endregion
    }
}