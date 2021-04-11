using System.Web;
using System.Web.Mvc;

namespace aspbet_mvc_beginner
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
