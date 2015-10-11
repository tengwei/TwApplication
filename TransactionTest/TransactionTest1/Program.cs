using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TransactionTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("开始");
            Console.Read();
            //EditProducts();
            EditProducts1();
            //CreateProducts();
            //ThreadPool.QueueUserWorkItem(p=> Program.EditProducts1());
            //ThreadPool.QueueUserWorkItem(p => Program.EditProducts2());
            Console.Write("成功");
            Console.Read();
           
        }

        public static void CreateProducts()
        {
            using (var dbContext = new TwTransactionTest())
            {
                dbContext.Product.Add(new Product()
                {
                    Deleted = false,
                    Name = "Name_",
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                });
                dbContext.SaveChanges();
            }

        }

        public static void EditProducts1()
        {
            try
            {
                using (var dbContext = new TwTransactionTest())
                {
                    //using (var transaction = dbContext.Database.BeginTransaction())
                    using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
                    {
                        try
                        {
                            var Product = dbContext.Product.FirstOrDefault(p => p.Id == 2);
                            Product.Name = "123";

                            dbContext.SaveChanges();
                           transaction.Commit();

                        }
                        catch( Exception ex)
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

        public static void EditProducts2()
        {
            try
            {
                using (var dbContext = new TwTransactionTest())
                {
                    using (var transaction = dbContext.Database.BeginTransaction())
                    {
                        var Product = dbContext.Product.FirstOrDefault(p => p.Id == 2);
                        Product.Name = "123456";

                        dbContext.SaveChanges();
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static void CreateOrders()
        {
            try
            {
                using (var dbContext = new TwTransactionTest())
                {
                    //using (var con = dbContext.Database.BeginTransaction())
                    {
                        var order = new Order()
                        {
                            OrderGuid = Guid.NewGuid(),
                            Deleted = false,
                            CreateTime = DateTime.Now,
                            UpdateTime = DateTime.Now
                        };
                        dbContext.Order.Add(order);
                        //dbContext.SaveChanges();
                        //dbContext.OrderPost.Add(new OrderPost()
                        //{
                        //    OrderId = order.Id,
                        //    CreateTime = DateTime.Now,
                        //    UpdateTime = DateTime.Now,
                        //    CreateId = i,
                        //    UpdateId = j,
                        //});

                        //Random randomOrderItem = new Random(1);
                        //var orderItemCount = randomOrderItem.Next(20);
                        //for (int m = 1; m <= orderItemCount; m++)
                        //{
                        //    Random random = new Random(1);
                        //    var index = random.Next(1459000);
                        //    dbContext.OrderItem.Add(new OrderItem()
                        //    {
                        //        OrderId = order.Id,
                        //        OrderItemGuid = Guid.NewGuid(),
                        //        ProductId = index,
                        //        ProductName = "Name_" + "0" + index
                        //    });
                        //}
                        dbContext.SaveChanges();
                        //con.Commit();
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
