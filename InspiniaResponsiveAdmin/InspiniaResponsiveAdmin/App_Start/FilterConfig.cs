using System.Web.Mvc;
using InspiniaResponsiveAdmin.Filter;

namespace InspiniaResponsiveAdmin {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthAttributeFilterAcl());
        }
    }
}
