using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace one_to_oneEFWithoutFluentAPI.Models
{
    public class Biography
    {
        [Key]
        public int BioId { get; set; } 
        public string Details { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Author author { get; set; }
    }
}
