using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        PagedResult<Customer> GetEnabled(int pageIndex, int pageSize);
    }
}
