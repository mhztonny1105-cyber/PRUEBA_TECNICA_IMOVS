using System.Web;
using System.Web.Mvc;

namespace PRUEBA_TECNICA_IMOVS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
