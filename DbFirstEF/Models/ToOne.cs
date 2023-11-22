using System;
using System.Collections.Generic;

namespace DbFirstEF.Models
{
    public partial class ToOne
    {
        public int Id { get; set; }
        public int RelatedToOneId { get; set; }

        public virtual One RelatedToOne { get; set; } = null!;
    }
}
