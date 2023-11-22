using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmpSys
{
    public class Employee1
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int Salary { get; set; }
        public DateTime DOB { get; set; }
        public bool IsActive { get; set; }
        public List<Designation1> Employees { get; set; }


    }
    public class Designation1
    {
        [Key]
        public int Id { get; set; }
        public string DesignationName { get; set; }
        public Employee1 Role { get; set; }

    }
    public class RanaDbContext : DbContext 
    {
        public DbSet<Employee1> Employee1 { get; set; }
        public DbSet<Designation1> Designation1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RanaDb;Trusted_Connection=true");
        }
    }

}