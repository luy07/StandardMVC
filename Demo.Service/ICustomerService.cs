using Demo.Domain; 
using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{
    public interface ICustomerService : IService
    {
        PagedResult<Customer> GetEnableCustomer(int pageIndex, int pageSize);
    }
}
