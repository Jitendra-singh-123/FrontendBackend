using System;
using System.Collections.Generic;

namespace DataBaseFirstApproachBookContext.Models
{
    public partial class BooksTable
    {
        public int Id { get; set; }

        //name cannot be null
        public string Name { get; set; } = null!;
        public double? Price { get; set; }
        public string? Author { get; set; }
    }
}
