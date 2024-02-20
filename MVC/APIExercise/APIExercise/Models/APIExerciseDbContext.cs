using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIExercise.Models
{
    public partial class APIExerciseDbContext : DbContext
    {
        public APIExerciseDbContext()
        {
        }

        public APIExerciseDbContext(DbContextOptions<APIExerciseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;database=APIExerciseDb;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Bid)
                    .HasName("PK__Book__C6DE0CC14BC0A2B2");

                entity.ToTable("Book");

                entity.Property(e => e.Bid)
                    .ValueGeneratedNever()
                    .HasColumnName("BId");

                entity.Property(e => e.AuthorName).HasMaxLength(100);

                entity.Property(e => e.Bname)
                    .HasMaxLength(100)
                    .HasColumnName("BName");

                entity.Property(e => e.Bprice)
                    .HasColumnType("money")
                    .HasColumnName("BPrice");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Book__CategoryId__3A81B327");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Category__C1F8DC395820143A");

                entity.ToTable("Category");

                entity.HasIndex(e => e.Category1, "UQ__Category__4BB73C32B68BB22B")
                    .IsUnique();

                entity.Property(e => e.Cid)
                    .ValueGeneratedNever()
                    .HasColumnName("CId");

                entity.Property(e => e.Category1)
                    .HasMaxLength(50)
                    .HasColumnName("Category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
