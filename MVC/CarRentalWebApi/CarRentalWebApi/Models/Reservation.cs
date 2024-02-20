using System;
using System.Collections.Generic;

namespace CarRentalWebApi.Models
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime PickupDateTime { get; set; }
        public DateTime DropOffDateTime { get; set; }
        public string OptionalExtras { get; set; } = null!;

        public virtual Vehicle Car { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
