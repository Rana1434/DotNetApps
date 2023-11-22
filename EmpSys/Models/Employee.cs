using System;
using System.Collections.Generic;

namespace EmpSys.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; } = null!;
        public int Salary { get; set; }
        public DateTime Dob { get; set; }
        public int RoleId { get; set; }

        public virtual Designation Role { get; set; } = null!;
    }
}
