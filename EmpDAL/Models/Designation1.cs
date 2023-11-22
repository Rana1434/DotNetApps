using System;
using System.Collections.Generic;

namespace EmpDAL.Models
{
    public partial class Designation1
    {
        public int Id { get; set; }
        public string DesignationName { get; set; } = null!;
        public int RoleEmpId { get; set; }

        public virtual Employee1 RoleEmp { get; set; } = null!;
    }
}
