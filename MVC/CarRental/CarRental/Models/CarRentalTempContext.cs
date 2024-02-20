using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarRental.Models
{
    public partial class CarRentalTempContext : DbContext
    {
        public CarRentalTempContext()
        {
        }

        public CarRentalTempContext(DbContextOptions<CarRentalTempContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;
        public virtual DbSet<VehicleInventory> VehicleInventories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=CarRentalTemp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).ValueGeneratedNever();

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.CarId).ValueGeneratedNever();

                entity.Property(e => e.Availability).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Make).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Pricing).HasColumnType("money");

                entity.Property(e => e.Specifications).HasMaxLength(250);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).ValueGeneratedNever();

                entity.Property(e => e.Rating).HasMaxLength(50);

                entity.Property(e => e.Review).HasMaxLength(50);

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_Feedback_Car");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.ReservationId).ValueGeneratedNever();

                entity.Property(e => e.DropoffDateTime).HasColumnType("datetime");

                entity.Property(e => e.OptionalExtras).HasMaxLength(50);

                entity.Property(e => e.PickupDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_Car");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserProfile");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.ContactInformation).HasMaxLength(12);

                entity.Property(e => e.PaymentDetails).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserProfile)
                    .HasForeignKey<UserProfile>(d => d.UserId)
                    .HasConstraintName("FK_UserProfile_User");
            });

            modelBuilder.Entity<VehicleInventory>(entity =>
            {
                entity.HasNoKey(e => e.VehicleID));

                entity.ToTable("VehicleInventory");

                entity.Property(e => e.AvailabilityStatus).HasMaxLength(50);

                entity.Property(e => e.Maintenance).HasColumnType("text");

                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
