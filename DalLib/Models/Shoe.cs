using System;
using System.Collections.Generic;

namespace DalLib.Models
{
    public partial class Shoe
    {
        public Shoe()
        {
            OrderShoes = new HashSet<OrderShoe>();
        }

        public int ShoeId { get; set; }
        public string Gender { get; set; } = null!;
        public double ShoePrice { get; set; }
        public string ShoeStyle { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string ShoeColor { get; set; } = null!;
        public int ShoeSize { get; set; }

        public virtual ICollection<OrderShoe> OrderShoes { get; set; }
    }
}
