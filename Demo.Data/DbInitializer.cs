using Demo.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class YmtCS_DbInitializer : DropCreateDatabaseAlways<YmatouUnitOfWork>
    {
        List<Customer> customers = new List<Customer>();

        public YmtCS_DbInitializer()
        {
            customers.Add(new Customer() { Id=1,FirstName="David",LastName="Hanson",Birthday=new DateTime(1988,7,24),Address="Sanfransisco DLT. North Street"  });
        }

        protected override void Seed(YmatouUnitOfWork context)
        {
            //做一些数据初始化工作
            foreach (var item in customers)
            {
                context.Set<Customer>().Add(item);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
