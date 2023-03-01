using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain
{
    /// <summary>
    /// 顾客
    /// </summary>
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age
        {
            get
            {
                return (DateTime.Now - Birthday).Days / 365;
            }
        }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public bool IsDel { get; set; }
    }
}
