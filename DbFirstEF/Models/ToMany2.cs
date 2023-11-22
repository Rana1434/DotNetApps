using System;
using System.Collections.Generic;

namespace DbFirstEF.Models
{
    public partial class ToMany2
    {
        public ToMany2()
        {
            Manys = new HashSet<Many>();
        }

        public int Id { get; set; }

        public virtual ICollection<Many> Manys { get; set; }
    }
}
