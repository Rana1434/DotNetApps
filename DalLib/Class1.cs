using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DalLib
{
    public class Customer
    {
        [Key]
        public int custId { get; set; }
        public string custName { get; set; }
        public string custAddress { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }

    public class Orders
    {
        [Key]
        public int orderId { get; set; }
        public int OrderDate { get; set; }
        public ICollection<OrderShoes> OrderShoes { get; set; }
    }

    public class OrderShoes
    {
        [Key]
        public int orderedId { get; set; }
        //public Shoes Id { get; set; }
        //public Orders Id { get; set; }
        public int Quantity { get; set; }

    }

    public class Shoes
    {
        [Key]
        public int shoeId { get; set; }
        public string Gender { get; set; }
        public double shoePrice { get; set; }
        public string shoeStyle { get; set; }
        public string Image { get; set; }
        public string shoeColor { get; set; }
        public int shoeSize { get; set; }
        public ICollection<OrderShoes> OrderShoes { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }

    public enum Style
    {

        Sneakers,
        Boots,
        Sports
    }

    public enum Color
    {
        Black,
        White,
        Red,
        Green,
        Blue,
        Pink
    }


    public class SSDbContext : DbContext
    {
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<OrderShoes> OrderShoes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SSDb;Trusted_Connection=true");
        }
    }
}