using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionTest;

namespace TransactionWeb1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            EditProducts1();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public  void EditProducts1()
        {
            try
            {
                using (var dbContext = new TwTransactionTest())
                {
                    using (var transaction = dbContext.Database.BeginTransaction())
                    //using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
                   // using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
                    {
                        try
                        {
                            var Product = dbContext.Product.FirstOrDefault(p => p.Id == 2);
                            Product.Name = "123";

                            dbContext.SaveChanges();
                            Product.Name = "1234";
                            dbContext.SaveChanges();
                            transaction.Commit();

                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                        }


                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}