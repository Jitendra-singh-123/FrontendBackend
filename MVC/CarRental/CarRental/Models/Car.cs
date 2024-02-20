using System;
using System.Collections.Generic;

namespace CarRental.Models
{
    public partial class Car
    {
        public Car()
        {
            Feedbacks = new HashSet<Feedback>();
            Reservations = new HashSet<Reservation>();
        }

        public int CarId { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Specifications { get; set; } = null!;
        public decimal Pricing { get; set; }
        public string Availability { get; set; } = null!;

        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
