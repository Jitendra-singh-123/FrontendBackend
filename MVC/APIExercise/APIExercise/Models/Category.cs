using System;
using System.Collections.Generic;

namespace APIExercise.Models
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public int Cid { get; set; }
        public string Category1 { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
