using System;
using System.Collections.Generic;

namespace CarRentalProj.Models
{
    public partial class UserProfile
    {
        public int UserId { get; set; }
        public string ContactInformation { get; set; } = null!;
        public string PaymentDetails { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
