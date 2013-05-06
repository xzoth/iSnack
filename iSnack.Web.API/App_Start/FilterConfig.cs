using System.Web;
using System.Web.Mvc;
using iSnack.Web.API.Filter;

namespace iSnack.Web.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}