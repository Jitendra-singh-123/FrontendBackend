using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiEF.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId {  get; set; }
        public string Name { get; set; }
        public List<Product>? productsList { get; set;}
    }
}
