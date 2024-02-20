using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapiexerciseEF.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [StringLength(100)]
        public string Title { get; set; }

        
        public int AuthorId {  get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author? Author { get; set; }

        public int GenreID { get; set; }
        [ForeignKey("GenreID")]
        public virtual Genre? Genre { get; set; }
    }
}
