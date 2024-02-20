using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoadOurOwnWebPage.Models
{
    public partial class EmpAPIContext : DbContext
    {
        public EmpAPIContext()
        {
        }

        public EmpAPIContext(DbContextOptions<EmpAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Emp> Emps { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=EmpAPI;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emp>(entity =>
            {
                entity.ToTable("Emp");

                entity.Property(e => e.Doj).HasColumnName("DOJ");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
