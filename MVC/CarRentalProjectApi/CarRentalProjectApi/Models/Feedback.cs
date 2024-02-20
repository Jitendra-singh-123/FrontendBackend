using System;
using System.Collections.Generic;

namespace CarRentalProjectApi.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int? UserId { get; set; }
        public int? CarId { get; set; }
        public double? Rating { get; set; }
        public string? Review { get; set; }
        public DateTime? ReviewDateTime { get; set; }

        public virtual CarListing? Car { get; set; }
        public virtual User? User { get; set; }
    }
}
