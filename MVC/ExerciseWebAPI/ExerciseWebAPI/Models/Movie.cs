using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseWebAPI.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int MId { get; set; }

        [Required]
        [StringLength(50)]
        public string MName { get; set; }

        [Required]
        [StringLength(50)]
        public string StarCast { get; set; }
        public string Producer { get; set;}

        [DefaultValue("Same as Producer")]
        public string Director { get; set;}

        public DateTime Date { get; set; }
    }
}
