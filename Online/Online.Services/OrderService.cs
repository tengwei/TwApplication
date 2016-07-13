using System;
using System.Collections.Generic;
using System.Linq;
using Online.DataBase;
using Online.IServices;
using Online.Models;

namespace Online.Services {
    public class OrderService : IService {
        public double Add(double n1, double n2) {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Subtract(double n1, double n2) {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Multiply(double n1, double n2) {
            double result = n1*n2;
            Console.WriteLine("Received Multiply({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Divide(double n1, double n2) {
            double result = n1/n2;
            Console.WriteLine("Received Divide({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public List<BaseModel> Get(string typeName) {
            using (var entities = new db_10140_archivesEntities()) {
                var datas = entities.db_API_Operationallog.AsNoTracking().Take(100).ToList().Select(p => (new TestModel() {
                    Id = 1,
                    id = p.id,
                    bak = p.bak,
                    events = p.events,
                    lastmoney = p.lastmoney,
                    money = p.money,
                    more = p.more,
                    nowmoney = p.money,
                    times = p.times,
                    
                }) as BaseModel).ToList();
                //var datas = entities.db_API_Operationallog.AsNoTracking().Take(100).ToList().Select(p => (new BaseModel() {
                //    TypeName = p.id.ToString(),
                  
                //}) as BaseModel).ToList();
               
                return datas;
            }
        }
    }
}
