using System;
using System.Collections.Generic;

namespace CarRentalWebApi.Models
{
    public partial class VehicleInventory
    {
        public int VehicleId { get; set; }
        public string AvailabilityStatus { get; set; } = null!;
        public string MaintenanceAlerts { get; set; } = null!;
    }
}
