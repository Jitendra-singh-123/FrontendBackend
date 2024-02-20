using System;
using System.Collections.Generic;

namespace BookStoreWebApp.Models
{
    public partial class Category
    {
        public Category()
        {
            BooksTables = new HashSet<BooksTable>();
        }

        public int Cid { get; set; }
        public string Cname { get; set; } = null!;

        public virtual ICollection<BooksTable> BooksTables { get; set; }
    }
}
