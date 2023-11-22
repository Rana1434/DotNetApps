using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbFirstEF.Models
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext()
        {
        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Many> Manys { get; set; } = null!;
        public virtual DbSet<One> Ones { get; set; } = null!;
        public virtual DbSet<Parent> Parents { get; set; } = null!;
        public virtual DbSet<ToMany2> ToMany2s { get; set; } = null!;
        public virtual DbSet<ToOne> ToOnes { get; set; } = null!;
        public virtual DbSet<TooMany1> TooMany1s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TestDb;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Many>(entity =>
            {
                entity.HasMany(d => d.ToMany2s)
                    .WithMany(p => p.Manys)
                    .UsingEntity<Dictionary<string, object>>(
                        "ManyToMany2",
                        l => l.HasOne<ToMany2>().WithMany().HasForeignKey("ToMany2sId"),
                        r => r.HasOne<Many>().WithMany().HasForeignKey("ManysId"),
                        j =>
                        {
                            j.HasKey("ManysId", "ToMany2sId");

                            j.ToTable("ManyToMany2");

                            j.HasIndex(new[] { "ToMany2sId" }, "IX_ManyToMany2_ToMany2sId");
                        });
            });

            modelBuilder.Entity<One>(entity =>
            {
                entity.HasIndex(e => e.ToManyId, "IX_Ones_toManyId");

                entity.Property(e => e.ToManyId).HasColumnName("toManyId");

                entity.HasOne(d => d.ToMany)
                    .WithMany(p => p.Ones)
                    .HasForeignKey(d => d.ToManyId);
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.HasKey(e => e.ParentKey);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ToMany2>(entity =>
            {
                entity.ToTable("toMany2s");
            });

            modelBuilder.Entity<ToOne>(entity =>
            {
                entity.ToTable("toOnes");

                entity.HasIndex(e => e.RelatedToOneId, "IX_toOnes_RelatedToOneId");

                entity.HasOne(d => d.RelatedToOne)
                    .WithMany(p => p.ToOnes)
                    .HasForeignKey(d => d.RelatedToOneId);
            });

            modelBuilder.Entity<TooMany1>(entity =>
            {
                entity.ToTable("tooMany1s");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
