using System;
using System.Collections.Generic;

namespace CarRentalProjectApi.Models
{
    public partial class User
    {
        public User()
        {
            Feedbacks = new HashSet<Feedback>();
            PaymentDetails = new HashSet<PaymentDetail>();
            Reservations = new HashSet<Reservation>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? EmailAddress { get; set; }
        public string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? LicenseNumber { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
