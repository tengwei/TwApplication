using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Log4NetEx {
    public class QueueErrorAttribute : HandleErrorAttribute {
        public static Queue<Exception> ExceptionQueue = new Queue<Exception>();
        public override void OnException(ExceptionContext filterContext) {
            ExceptionQueue.Enqueue(filterContext.Exception);
            filterContext.HttpContext.Response.Redirect("~/Error.html");
            base.OnException(filterContext);
        }
    }
}