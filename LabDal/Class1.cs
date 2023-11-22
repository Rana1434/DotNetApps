using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestDal;

namespace LabDal
{
    public class Student
    {
        [Key]
        public int StudentKey { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public string CourseName { get; set; }
        [Range(18, 110)]
        public int NoOfCourses { get; set; }
    }

    public class ManyCourse
    {
        [Key]
        public int Id { get; set; }
        public List<Student> ManyCourses { get; set; }
    }

    public class ManyStudent
    {
        [Key]
        public int Id { get; set; }
        public List<Course> ManyStudents { get; set; }
    }

    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public Student StudentToOneComp { get; set; }
    }
    public class TestDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ManyCourse> ManyCourses { get; set; }
        public DbSet<ManyStudent> ManyStudents { get; set; }
        public DbSet<Company> Companies { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=StudentDb;Trusted_Connection=true");
        }

        
    }
}