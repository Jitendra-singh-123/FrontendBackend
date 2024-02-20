using System;
using System.Collections.Generic;

namespace CarRentalProjectApi.Models
{
    public partial class CarListing
    {
        public CarListing()
        {
            Feedbacks = new HashSet<Feedback>();
            PaymentDetails = new HashSet<PaymentDetail>();
            Reservations = new HashSet<Reservation>();
        }

        public int CarId { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? Location { get; set; }
        public string? Specifications { get; set; }
        public decimal? DailyPrice { get; set; }
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set; }
        public string? ImageUrl { get; set; }
        public string? CarPlateNumber { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
