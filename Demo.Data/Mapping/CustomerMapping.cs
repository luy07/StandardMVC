using Demo.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Mapping
{
    public class CustomerEntityTypeConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerEntityTypeConfiguration()
        {
            ToTable("Customers");
        }
    }
}
