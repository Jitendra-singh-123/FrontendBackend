using System;
using System.Collections.Generic;

namespace CarRentalProj.Models
{
    public partial class VehicleInventory
    {
        public int VehicleId { get; set; }
        public string AvailabilityStatus { get; set; } = null!;
        public string Maintenance { get; set; } = null!;
    }
}
