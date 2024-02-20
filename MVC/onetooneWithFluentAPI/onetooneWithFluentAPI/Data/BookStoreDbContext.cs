using Microsoft.EntityFrameworkCore;
using onetooneWithFluentAPI.Models;

namespace onetooneWithFluentAPI.Data
{
    public class BookStoreDbContext : DbContext
    {
       
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-FDJLT93A;Database=FluentAPIOnetoOne;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasOne(a => a.Biography)
                .WithOne(b => b.Author)
                .HasForeignKey<Biography>(b => b.AuthorId);


        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Biography> Biographies { get; set; }

    }
}