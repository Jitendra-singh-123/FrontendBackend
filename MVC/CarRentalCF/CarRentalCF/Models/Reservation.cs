using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalCF.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set;}

        [ForeignKey("CarListing")]
        public int? CarId { get; set;}


        public DateTime? PickupDateTime { get; set;}

        public DateTime? DropoffDateTime { get; set; }
   
        public virtual User? User { get; set; }
        public virtual CarListing? CarListing { get; set; }
    }
}
