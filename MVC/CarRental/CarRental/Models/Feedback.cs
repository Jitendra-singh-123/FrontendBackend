using System;
using System.Collections.Generic;

namespace CarRental.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string Rating { get; set; } = null!;
        public string Review { get; set; } = null!;

        public virtual Car Car { get; set; } = null!;
    }
}
