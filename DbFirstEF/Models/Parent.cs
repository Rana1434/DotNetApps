using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbFirstEF.Models
{
    public partial class Parent
    {
        public int ParentKey { get; set; }
        [Column("ParentName")]
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public string Discriminator { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public int? Age { get; set; }
        public int? AgeofChild2 { get; set; }
        public DateTime? BirthDateOfChild2 { get; set; }
    }
}
