using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppEntity.Models
{
    [Table("FilmIndustry")]
    public class FilmIndustry
    {
        [Key]
        public int MId { get; set; }

        [Required(ErrorMessage = "Movie name is required")]
        [MaxLength(255)]
        [DisplayName("Manager Name")]
        public string MName { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "Star cast names are required")]
        public string StarCast { get; set; }


        [MaxLength(255)]
        [Required(ErrorMessage = "Producer name is required")]
        public string Producer { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "Director name is required")]
        [DefaultValue("Unknown")]
        public string Director { get; set; }



        [Required]
        [Column(TypeName = "date")]
        
        public DateTime ReleaseDate { get; set; }
    }
}
