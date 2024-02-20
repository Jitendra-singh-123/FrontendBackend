using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace one_to_oneEFWithoutFluentAPI.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string Name { get; set; }

        [ForeignKey("Biography")]
        public int BioId {  get; set; }
        public virtual Biography biography { get; set; }
    }
}
