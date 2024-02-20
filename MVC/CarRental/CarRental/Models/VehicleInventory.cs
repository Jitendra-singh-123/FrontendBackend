using System;
using System.Collections.Generic;

namespace CarRental.Models
{
    public partial class VehicleInventory
    {
        public int VehicleId { get; set; }
        public string AvailabilityStatus { get; set; } = null!;
        public string Maintenance { get; set; } = null!;
    }
}
