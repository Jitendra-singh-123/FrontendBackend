using Microsoft.EntityFrameworkCore;

namespace WebApiEF.Models
{
    public class ProductsDbContext: DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) {
            
        }

        public DbSet<Product> Products { get; set;}
        public DbSet<Category> Categories { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
