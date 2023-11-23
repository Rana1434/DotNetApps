using System;
using System.Collections.Generic;

namespace DalLib.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderShoes = new HashSet<OrderShoe>();
        }

        public int OrderId { get; set; }
        public int OrderDate { get; set; }
        public int? CustomercustId { get; set; }

        public virtual Customer? Customercust { get; set; }
        public virtual ICollection<OrderShoe> OrderShoes { get; set; }
    }
}
