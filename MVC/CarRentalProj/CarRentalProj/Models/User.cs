using System;
using System.Collections.Generic;

namespace CarRentalProj.Models
{
    public partial class User
    {
        public User()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; } = null!;

        public virtual UserProfile? UserProfile { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
