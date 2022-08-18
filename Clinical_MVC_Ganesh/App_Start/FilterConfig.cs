using System.Web;
using System.Web.Mvc;

namespace Clinical_MVC_Ganesh
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
