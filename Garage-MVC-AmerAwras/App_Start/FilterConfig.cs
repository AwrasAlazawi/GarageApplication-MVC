using System.Web;
using System.Web.Mvc;

namespace Garage_MVC_AmerAwras
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
