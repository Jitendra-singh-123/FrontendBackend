using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapiexerciseEF.Models
{
    [Table("Author")]
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public string Bio {  get; set; }

    }
}
