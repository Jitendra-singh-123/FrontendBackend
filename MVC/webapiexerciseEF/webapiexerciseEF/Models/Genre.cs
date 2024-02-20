using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapiexerciseEF.Models
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }

        [StringLength(100)]
        public string GenreName { get; set; }

    }
}
