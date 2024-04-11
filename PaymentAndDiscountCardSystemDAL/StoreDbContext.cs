using Microsoft.EntityFrameworkCore;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.AmountDiscountCards;
using PaymentAndDiscountCardSystemDomain.Entity.Cards.DiscountCards.TimeLimitedDiscountCard.Implementation;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemDomain.Entity.Orders;
using PaymentAndDiscountCardSystemDomain.Entity.OrdersItems;
using PaymentAndDiscountCardSystemDomain.Entity.Products;
using PaymentAndDiscountCardSystemDomain.Entity.Users;
using System.Data.Common;

namespace PaymentAndDiscountCardSystemDAL
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<AmountDiscountCard> AmountDiscountCards { get; set; }
        public DbSet<FunnyCard> FunnyCards{ get; set; }
        public DbSet<QuantumCard> QuantumCards{ get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrdersItems { get; set;}
        

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          // modelBuilder.Entity<OrderItem>().HasNoKey();
        
        
        }
    }
    
}
