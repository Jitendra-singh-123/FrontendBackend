using System;
using System.Collections.Generic;

namespace CarRentalProjectApi.Models
{
    public partial class PaymentDetail
    {
        public int PaymentId { get; set; }
        public int? UserId { get; set; }
        public int? CarId { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string? AccountDetails { get; set; }
        public string? CardDetails { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionStatus { get; set; }
        public DateTime? TransactionDate { get; set; }

        public virtual CarListing? Car { get; set; }
        public virtual User? User { get; set; }
    }
}
