using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalCF.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }


        [Required]
        [StringLength(50)]
        public string UserName { get; set; } 

        [Required]
        [StringLength(100)]
        public string Password { get; set; }


        public string? Role { get; set; }
    }
}
