using System;
using System.Collections.Generic;

namespace DalLib.Models
{
    public partial class OrderShoe
    {
        public int OrderedId { get; set; }
        public int Quantity { get; set; }
        public int? OrdersorderId { get; set; }
        public int? ShoesshoeId { get; set; }

        public virtual Order? Ordersorder { get; set; }
        public virtual Shoe? Shoesshoe { get; set; }
    }
}
