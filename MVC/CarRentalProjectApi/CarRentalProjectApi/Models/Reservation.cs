using System;
using System.Collections.Generic;

namespace CarRentalProjectApi.Models
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int? UserId { get; set; }
        public int? CarId { get; set; }
        public DateTime? PickupDateTime { get; set; }
        public DateTime? DropoffDateTime { get; set; }

        public virtual CarListing? Car { get; set; }
        public virtual User? User { get; set; }
    }
}
