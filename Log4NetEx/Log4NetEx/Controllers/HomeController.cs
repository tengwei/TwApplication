using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Log4Net.Ex;
using MongoDB.Driver;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Log4NetEx.Controllers {
    public class HomeController : Controller {
        readonly ILog logger = LogManager.GetLogger(ModuleEnum.订单.ToString());
        public ActionResult Index() {
            //log4net.ThreadContext.Properties["EventName"] = "EventName";
            //log4net.ThreadContext.Properties["UserIP"] = "UserIP";
            //log4net.GlobalContext.Properties["OurCompany.ApplicationName"] = "fubar";
            //try {
            //   throw new Exception("sadsa");
            //}
            //catch (Exception ex) {
            //    logger.Debug("werqwwq",ex);
                
            //}
            //logger.Debug(JsonConvert.SerializeObject(new {dsfsd="werewr",sdfds="52332"}));
            logger.Debug(new Log4NetMessageModel(){message = "失败"});
            logger.Info(new Log4NetMessageModel() { message = "失败" });
            //logger.Debug("wrety");
            //logger.Debug("wrety");
            //logger.Debug(new { Body = "Hello!" });
            //logger.Debug(new { ErrorMessage = "Something went wrong!" });
            //log4net.ThreadContext.Properties["EventName"] = "EventName";
            //log4net.ThreadContext.Properties["UserIP"] = "UserIP";
            //log4net.GlobalContext.Properties["OurCompany.ApplicationName"] = "fubar";
            //logger.Debug(new { Key = "Hey", Value = "You?" });
            //throw new Exception("123456");
            //Session["UserAgent"] = Request.UserAgent;
            //ViewData.Model = "访问状态已分布式存储session";
            //Thread.Sleep(10000);

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Log4Net");
            var collection = database.GetCollection<Log4NetMessageModel>("Log4NetLog");

            return View();
        }

        public ActionResult About() {
            ViewData.Model = Session["UserAgent"];
            ViewBag.Message = "Your application description page.";
            RedisHelper redis = new RedisHelper(1);

            #region String

            string str = "123";
            Demo demo = new Demo() {
                Id = 1,
                Name = "123"
            };
            var resukt = redis.StringSet("redis_string_test", str);
            var str1 = redis.StringGet("redis_string_test");
            redis.StringSet("redis_string_model", demo);
            var model = redis.StringGet<Demo>("redis_string_model");

            for (int i = 0; i < 10; i++) {
                redis.StringIncrement("StringIncrement", 2);
            }
            for (int i = 0; i < 10; i++) {
                redis.StringDecrement("StringIncrement");
            }
            redis.StringSet("redis_string_model1", demo, TimeSpan.FromSeconds(10));

            #endregion String

            #region List

            for (int i = 0; i < 10; i++) {
                redis.ListRightPush("list", i);
            }

            for (int i = 10; i < 20; i++) {
                redis.ListLeftPush("list", i);
            }
            var length = redis.ListLength("list");

            var leftpop = redis.ListLeftPop<string>("list");
            var rightPop = redis.ListRightPop<string>("list");

            var list = redis.ListRange<int>("list");

            #endregion List

            #region Hash

            redis.HashSet("user", "u1", "123");
            redis.HashSet("user", "u2", "1234");
            redis.HashSet("user", "u3", "1235");
            var news = redis.HashGet<string>("user", "u2");

            #endregion Hash

            #region 发布订阅

            redis.Subscribe("Channel1");
            for (int i = 0; i < 10; i++) {
                redis.Publish("Channel1", "msg" + i);
                if (i == 2) {
                    redis.Unsubscribe("Channel1");
                }
            }

            #endregion 发布订阅

            #region 事务

            var tran = redis.CreateTransaction();

            tran.StringSetAsync("tran_string", "test1");
            tran.StringSetAsync("tran_string1", "test2");
            bool committed = tran.Execute();

            #endregion 事务

            #region Lock

            var db = redis.GetDatabase();
            RedisValue token = Environment.MachineName;
            if (db.LockTake("lock_test", token, TimeSpan.FromSeconds(10))) {
                try {
                    //TODO:开始做你需要的事情
                    Thread.Sleep(5000);
                }
                finally {
                    db.LockRelease("lock_test", token);
                }
            }

            #endregion Lock
            return View();
        }
        [OutputCache(Duration = 60, VaryByParam = "*")]
        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";
            ViewData.Model = DateTime.Now.ToString();
            return View();
        }
    }

    public class Demo {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}