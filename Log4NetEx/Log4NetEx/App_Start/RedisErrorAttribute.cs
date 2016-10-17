using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Log4NetEx {
    public class RedisErrorAttribute : HandleErrorAttribute {
       
        public override void OnException(ExceptionContext filterContext) {
            RedisHelper redis = new RedisHelper(1);
            redis.ListRightPush("errorMsg", "234234234");
            filterContext.HttpContext.Response.Redirect("~/Error.html");
            base.OnException(filterContext);
        }
    }
}



        