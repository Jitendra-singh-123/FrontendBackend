using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRentalCF.Models;

namespace CarRentalCF.Data
{
    public class CarRentalCFContext : DbContext
    {
        public CarRentalCFContext (DbContextOptions<CarRentalCFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarRentalCF.Models.Admin> Admin { get; set; } = null!;

        public virtual DbSet<CarRentalCF.Models.CarListing>? CarListing { get; set; } = null!;

        public virtual DbSet<CarRentalCF.Models.Feedback>? Feedback { get; set; } = null!;

        public virtual DbSet<CarRentalCF.Models.PaymentDetails>? PaymentDetails { get; set; } = null!;

        public virtual DbSet<CarRentalCF.Models.Reservation>? Reservation { get; set; } = null!;

        public virtual DbSet<CarRentalCF.Models.User>? User { get; set; }= null!;
    }
}
