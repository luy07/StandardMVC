using Demo.Domain;
using Demo.Domain.Customers; 
using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{
    public class CustomerService : ICustomerService
    {

        public CustomerService(ICustomerRepository cusomterRepo)
        {
            this.cusomterRepo = cusomterRepo;
        }


        public void Dispose()
        {
            cusomterRepo.Dispose();
        }


        private readonly ICustomerRepository cusomterRepo;


        public PagedResult<Customer> GetEnableCustomer(int pageIndex, int pageSize)
        {
            return cusomterRepo.GetEnabled(pageIndex, pageSize);
        }
    }
}
