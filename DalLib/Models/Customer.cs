using System;
using System.Collections.Generic;

namespace DalLib.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustId { get; set; }
        public string CustName { get; set; } = null!;
        public string CustAddress { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
