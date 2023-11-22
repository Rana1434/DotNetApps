using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
    public class Employee
    {
        [Required]
        public int EmpId { get; set; }
        [MaxLength(100)]
        public string Designation { get; set; }

        [Range(double.MinValue, double.MaxValue)]
        public int Salary { get; set; }
        [MaxLength(100)]
        public string EmpName { get; set; }

        public bool IsActive { get; set; }
    }
    public class EmployeeOperations
    {
        static List<Employee> _employee = new List<Employee>();
        public static List<Employee> GetAllEmployee()
        {
            if (_employee.Count == 0)
            {
                _employee.Add(new Employee() { EmpId = 420, Designation = "Analyst", Salary = 500000, EmpName = "Rana", IsActive = true });
                _employee.Add(new Employee() { EmpId = 421, Designation = "Analyst", Salary = 500000, EmpName = "Vana", IsActive = true });
                _employee.Add(new Employee() { EmpId = 400, Designation = "Manager", Salary = 1500000, EmpName = "Mana", IsActive = true });

            }
            return _employee;
        }

        public static Employee Search(int pEmpId)
        {
            return GetAllEmployee().Where(p => p.EmpId == pEmpId).FirstOrDefault();
        }

        internal static void CreateNew(Employee e)
        {
            _employee.Add(e);
        }
    }
}
