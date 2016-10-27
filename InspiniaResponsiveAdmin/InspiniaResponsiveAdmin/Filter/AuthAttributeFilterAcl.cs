using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InspiniaResponsiveAdmin.Filter {

     [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class AuthAttributeFilterAcl : ActionFilterAttribute {
        //不能录也可以有的权限
         private static readonly List<string> Powerlist = new List<string> { 
                "Account/Login".ToLower()
            };
        public override void OnActionExecuting (ActionExecutingContext filterContext) {
           
            string action = filterContext.RouteData.Values["action"].ToString().ToLower();
            string controller = filterContext.RouteData.Values["controller"].ToString().ToLower();
            //pass 登录相关
            if (Powerlist.Any(s => s == (controller + "/" + action))) {
                return;
            }
            if (!filterContext.HttpContext.Request.IsAuthenticated) {
                filterContext.Result = new RedirectResult("/Account/Login"); 
            }
        }
    }
}