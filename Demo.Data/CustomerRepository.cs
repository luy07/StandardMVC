using Data.Seedwork;
using Demo.Domain;
using Demo.Domain.Customers;
using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class CustomerRepository : Repository<Customer>,ICustomerRepository
    {
        public CustomerRepository(IQueryableUnitOfWork unitOfWork):base(unitOfWork)
        {

        }

        public PagedResult<Customer> GetEnabled(int pageIndex, int pageSize)
        {
            return base.GetPaged(pageIndex, pageSize, CustomerSpecifications.EnableCustomers(),r=>r.Id,false);
        }
    }
}
