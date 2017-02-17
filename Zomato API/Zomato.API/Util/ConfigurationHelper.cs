using System.Configuration;

namespace Zomato.API.Util
{
    internal static class ConfigurationHelper
    {
        #region Internal Static Methods
        internal static string GetApiKey()
        {
            return ConfigurationManager.AppSettings["ZOMATO_API_KEY"];
        }
        #endregion
    }
}