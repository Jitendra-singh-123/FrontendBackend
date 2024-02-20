using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalCF.Models
{
    [Table("PaymentDetails")]
    public class PaymentDetails
    {
        [Key]
        public int PaymentId  { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [ForeignKey("CarListing")]
        public int? CarId { get; set;}

        [Required]
        [StringLength(50)]
        [RegularExpression(@"CreditCard|DebitCard|Online|Cash")]
        public string PaymentMethod { get; set; }

        public string? AccountDetails { get; set; }

        public string? CardDetails { get; set; }

        [Required]
        public double Amount { get; set; }

        [StringLength(50)]
        [RegularExpression(@"Success|Failed")]
        public string? TransactionStatus { get; set; }

        public DateTime? TransactionDate { get; set; }



        public virtual User? User { get; set; }
        public virtual CarListing? CarListing { get; set; }







    }
}
