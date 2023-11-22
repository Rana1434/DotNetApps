using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDal
{

    public class One
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
    }
    public class toOne {
        [Key]
        public int Id { get; set; }
        public One RelatedToOne { get; set; }
    }
    public class toMany {
        [Key]   
        public int Id { get; set; }
        public List<One> TooManyOnes { get; set; }
    }
    public class Many {
        [Key]
        public int Id { get; set; }
        public List <ToMany2> ToMany2s { get;set; }
    }
    public class ToMany2 
    {
        [Key]
        public int Id { get; set; }
        public List<Many>Manys { get; set; }

    }
    public class Parent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParentKey { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
    public class Child:Parent {
        [NotMapped]
        public int ChildId { get; set;}

        public DateTime BirthDate { get; set; }
        [Range(18, 110)]
        public int Age { get; set; }
    }
    public class Child2 : Parent
    {
        [NotMapped]
        public int Child2Id { get; set; }

        public DateTime BirthDateOfChild2 { get; set; }
        [Range(18, 110)]
        public int AgeofChild2 { get; set; }
    }
    
    public class TestDbContext : DbContext
    {

        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Child2> Children2 { get; set; }
        public DbSet<One> Ones { get; set; }
        public DbSet<toOne> toOnes { get; set; }
        public DbSet<toMany> tooMany1s { get; set; }
        public DbSet<Many>Manys {  get; set; }
        public DbSet<ToMany2> toMany2s {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TestDb;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parent>().Property(p => p.ParentKey).UseIdentityColumn();
            modelBuilder.Entity<Parent>().HasOne<Child>();
            modelBuilder.Entity<One>().HasMany<Many>();
            modelBuilder.Entity<Parent>().HasOne<Parent>();
            modelBuilder.Entity<Parent>().Property(p=>p.ParentKey).IsRequired();
        }
    }
}