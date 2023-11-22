using System;
using System.Collections.Generic;

namespace EmpDAL.Models
{
    public partial class Employee1
    {
        public Employee1()
        {
            Designation1s = new HashSet<Designation1>();
        }

        public int EmpId { get; set; }
        public string EmpName { get; set; } = null!;
        public int Salary { get; set; }
        public DateTime Dob { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Designation1> Designation1s { get; set; }
    }
}
