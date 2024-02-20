using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStoreWebApp.Models
{
    public partial class DatabaseFirstApproachContext : DbContext
    {
        public DatabaseFirstApproachContext()
        {
        }

        public DatabaseFirstApproachContext(DbContextOptions<DatabaseFirstApproachContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BooksTable> BooksTables { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=DatabaseFirstApproach;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BooksTable>(entity =>
            {
                entity.ToTable("BooksTable");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Author).HasMaxLength(50);

                entity.Property(e => e.Bcategory).HasColumnName("BCategory");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.BcategoryNavigation)
                    .WithMany(p => p.BooksTables)
                    .HasForeignKey(d => d.Bcategory)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__BooksTabl__BCate__3A81B327");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.ToTable("Category");

                entity.Property(e => e.Cid)
                    .ValueGeneratedNever()
                    .HasColumnName("CId");

                entity.Property(e => e.Cname)
                    .HasMaxLength(50)
                    .HasColumnName("CName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
