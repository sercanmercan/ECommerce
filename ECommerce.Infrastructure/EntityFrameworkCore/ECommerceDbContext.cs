using ECommerce.Domain.Basket;
using ECommerce.Domain.Order;
using ECommerce.Domain.Product;
using ECommerce.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.EntityFrameworkCore
{
    public class ECommerceDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-817S9N1\SQLEXPRESS;Database=ECommerce;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
    }
}
