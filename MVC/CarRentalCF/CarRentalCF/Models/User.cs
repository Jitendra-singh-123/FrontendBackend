using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalCF.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string? EmailAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }


        [StringLength(20)]
        public string? PhoneNumber { get; set; }


        public string? Address {  get; set; }

        
        [StringLength(50)]
        public string? LicenseNumber { get; set; }


        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<PaymentDetails> PaymentDetails { get; set; }




    }
}
