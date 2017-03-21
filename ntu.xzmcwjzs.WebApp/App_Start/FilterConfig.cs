using System.Web;
using System.Web.Mvc;

namespace ntu.xzmcwjzs.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // filters.Add(new HandleErrorAttribute());
            filters.Add(new ntu.xzmcwjzs.WebApp.Common.MyAttributes.MyExceptionAttribute());
        }
    }
}
