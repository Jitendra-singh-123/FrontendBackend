using System;
using System.Collections.Generic;

namespace CarRentalWebApi.Models
{
    public partial class UserProfile
    {
        public int UserProfileId { get; set; }
        public string Contact { get; set; } = null!;
        public string PaymentDetails { get; set; } = null!;
    }
}
