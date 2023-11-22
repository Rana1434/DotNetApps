using System;
using System.Collections.Generic;

namespace DbFirstEF.Models
{
    public partial class TooMany1
    {
        public TooMany1()
        {
            Ones = new HashSet<One>();
        }

        public int Id { get; set; }

        public virtual ICollection<One> Ones { get; set; }
    }
}
