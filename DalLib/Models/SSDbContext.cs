using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DalLib.Models
{
    public partial class SSDbContext : DbContext
    {
        public SSDbContext()
        {
        }

        public SSDbContext(DbContextOptions<SSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderShoe> OrderShoes { get; set; } = null!;
        public virtual DbSet<Shoe> Shoes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SSDb;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.ToTable("Customer");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.CustAddress).HasColumnName("custAddress");

                entity.Property(e => e.CustName).HasColumnName("custName");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomercustId, "IX_Orders_CustomercustId");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.HasOne(d => d.Customercust)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomercustId);
            });

            modelBuilder.Entity<OrderShoe>(entity =>
            {
                entity.HasKey(e => e.OrderedId);

                entity.HasIndex(e => e.OrdersorderId, "IX_OrderShoes_OrdersorderId");

                entity.HasIndex(e => e.ShoesshoeId, "IX_OrderShoes_ShoesshoeId");

                entity.Property(e => e.OrderedId).HasColumnName("orderedId");

                entity.HasOne(d => d.Ordersorder)
                    .WithMany(p => p.OrderShoes)
                    .HasForeignKey(d => d.OrdersorderId);

                entity.HasOne(d => d.Shoesshoe)
                    .WithMany(p => p.OrderShoes)
                    .HasForeignKey(d => d.ShoesshoeId);
            });

            modelBuilder.Entity<Shoe>(entity =>
            {
                entity.Property(e => e.ShoeId).HasColumnName("shoeId");

                entity.Property(e => e.ShoeColor).HasColumnName("shoeColor");

                entity.Property(e => e.ShoePrice).HasColumnName("shoePrice");

                entity.Property(e => e.ShoeSize).HasColumnName("shoeSize");

                entity.Property(e => e.ShoeStyle).HasColumnName("shoeStyle");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
