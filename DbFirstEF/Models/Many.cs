using System;
using System.Collections.Generic;

namespace DbFirstEF.Models
{
    public partial class Many
    {
        public Many()
        {
            ToMany2s = new HashSet<ToMany2>();
        }

        public int Id { get; set; }

        public virtual ICollection<ToMany2> ToMany2s { get; set; }
    }
}
