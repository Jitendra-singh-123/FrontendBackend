using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalCF.Models
{
    [Table("CarListing")]
    public class CarListing
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        public string? Location { get; set; }

        public string? Specifications { get; set; }

        public double? DailyPrice { get; set; }

        
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set;}

        public string? ImageURL { get; set; }

        [StringLength(100)]
        public string? CarPlateNumber { get; set; }

        [RegularExpression(@"^(Available|NotAvailable|Returned)$")]
        public string? status { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<PaymentDetails> PaymentDetails { get; set; }


    }
}
