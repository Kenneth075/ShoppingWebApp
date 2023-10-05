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
    }
}
