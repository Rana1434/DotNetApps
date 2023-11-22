using System;
using System.Collections.Generic;

namespace EmpSys.Models
{
    public partial class Designation
    {
        public Designation()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string DesignationName { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
