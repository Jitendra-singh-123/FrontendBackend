using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalCF.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        public int FeedbackId {  get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [ForeignKey("CarListing")]
        public int? CarId { get; set;}

        public float? Rating { get; set;}

        public string? Review { get; set; }


        public DateTime? ReviewDateTime { get; set; }

        public virtual CarListing? CarListing { get; set; }

        public virtual User? User { get; set; }
    }
}
