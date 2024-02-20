using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarRentalProjectApi.Models
{
    public partial class RoadReadyContext : DbContext
    {
        public RoadReadyContext()
        {
        }

        public RoadReadyContext(DbContextOptions<RoadReadyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<CarListing> CarListings { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-FDJLT93A;Database=RoadReady;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<CarListing>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PK__CarListi__68A0340EF1C3C82E");

                entity.ToTable("CarListing");

                entity.HasIndex(e => e.CarPlateNumber, "UQ__CarListi__748419D19931BE7B")
                    .IsUnique();

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.AvailableFrom).HasColumnType("datetime");

                entity.Property(e => e.AvailableTo).HasColumnType("datetime");

                entity.Property(e => e.CarPlateNumber).HasMaxLength(30);

                entity.Property(e => e.DailyPrice).HasColumnType("money");

                entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");

                entity.Property(e => e.Make).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(20);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.ReviewDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Feedback__CarID__4E88ABD4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Feedback__UserID__4D94879B");
            });

            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__PaymentD__9B556A58E2512785");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionStatus).HasMaxLength(30);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PaymentDe__CarID__49C3F6B7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PaymentDe__UserI__48CFD27E");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.DropoffDateTime).HasColumnType("datetime");

                entity.Property(e => e.PickupDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Reservati__CarID__403A8C7D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Reservati__UserI__3F466844");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress, "UQ__Users__49A14740BC2429D9")
                    .IsUnique();

                entity.HasIndex(e => e.LicenseNumber, "UQ__Users__E8890166EC88B600")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.EmailAddress).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LicenseNumber).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
