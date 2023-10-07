using Microsoft.EntityFrameworkCore;

namespace ShoppingWebApp.Models
{
    public class ShoppingWebAppDbContext : DbContext
    {
        public ShoppingWebAppDbContext(DbContextOptions<ShoppingWebAppDbContext> options):base(options)
        {
            
        }

        public DbSet<Pies> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
