using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataBaseFirstApproachAPI.Models
{
    public partial class DatabaseFirstApproachAPISampleContext : DbContext
    {
        public DatabaseFirstApproachAPISampleContext()
        {
        }

        public DatabaseFirstApproachAPISampleContext(DbContextOptions<DatabaseFirstApproachAPISampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;database=DatabaseFirstApproachAPISample;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Courses__C1F8DC39606787F7");

                entity.Property(e => e.Cid)
                    .ValueGeneratedNever()
                    .HasColumnName("CId");

                entity.Property(e => e.Cname)
                    .HasMaxLength(50)
                    .HasColumnName("CName");

                entity.Property(e => e.Ctech)
                    .HasMaxLength(50)
                    .HasColumnName("CTech");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
