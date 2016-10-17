﻿using System.Web;
using System.Web.Mvc;

namespace Log4NetEx {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            //filters.Add(new HandleErrorAttribute());
            //filters.Add(new QueueErrorAttribute());
            filters.Add(new RedisErrorAttribute());  
        }
    }
}
