using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmpDAL.Models
{
    public partial class VanaDbContext : DbContext
    {
        public VanaDbContext()
        {
        }

        public VanaDbContext(DbContextOptions<VanaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Designation1> Designation1s { get; set; } = null!;
        public virtual DbSet<Employee1> Employee1s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=VanaDb;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Designation1>(entity =>
            {
                entity.ToTable("Designation1");

                entity.HasIndex(e => e.RoleEmpId, "IX_Designation1_RoleEmpId");

                entity.HasOne(d => d.RoleEmp)
                    .WithMany(p => p.Designation1s)
                    .HasForeignKey(d => d.RoleEmpId);
            });

            modelBuilder.Entity<Employee1>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("Employee1");

                entity.Property(e => e.Dob).HasColumnName("DOB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
