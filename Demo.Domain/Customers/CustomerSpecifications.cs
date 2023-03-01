using Domain.Seedwork.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Customers
{
    public static class CustomerSpecifications
    {
        public static Specification<Customer> EnableCustomers()
        { 
            return new DirectSpecification<Customer>(c=>c.IsDel==false);
        }
    }
}
