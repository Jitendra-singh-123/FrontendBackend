using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRentalSystemProject.Models;

namespace CarRentalSystemProject.Data
{
    public class CarRentalSystemProjectContext : DbContext
    {
        public CarRentalSystemProjectContext (DbContextOptions<CarRentalSystemProjectContext> options)
            : base(options)
        {
        }

        public DbSet<CarRentalSystemProject.Models.Car> Car { get; set; } = default!;

        public DbSet<CarRentalSystemProject.Models.Location>? Location { get; set; }

        public DbSet<CarRentalSystemProject.Models.Manufacturer>? Manufacturer { get; set; }

        public DbSet<CarRentalSystemProject.Models.Model>? Model { get; set; }

        public DbSet<CarRentalSystemProject.Models.Rental>? Rental { get; set; }

        public DbSet<CarRentalSystemProject.Models.Status>? Status { get; set; }

        public DbSet<CarRentalSystemProject.Models.VehicleType>? VehicleType { get; set; }
    }
}
