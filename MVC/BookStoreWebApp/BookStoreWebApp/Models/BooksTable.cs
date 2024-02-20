using System;
using System.Collections.Generic;

namespace BookStoreWebApp.Models
{
    public partial class BooksTable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double? Price { get; set; }
        public string? Author { get; set; }
        public int? Bcategory { get; set; }

        public virtual Category? BcategoryNavigation { get; set; }
    }
}
