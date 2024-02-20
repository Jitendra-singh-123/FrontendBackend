using System;
using System.Collections.Generic;

namespace CarRentalWebApi.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public decimal? Rating { get; set; }
        public string? Review { get; set; }

        public virtual Vehicle Car { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
