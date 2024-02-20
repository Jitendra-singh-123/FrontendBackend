using System;
using System.Collections.Generic;

namespace CarRentalWebApi.Models
{
    public partial class ReservationTable
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public DateTime DropOfDateTime { get; set; }
        public string OptionalExtras { get; set; } = null!;

        public virtual Vehicle Car { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
