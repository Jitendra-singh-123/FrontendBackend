using System;
using System.Collections.Generic;

namespace APIExercise.Models
{
    public partial class Book
    {
        public int Bid { get; set; }
        public string? Bname { get; set; }
        public decimal? Bprice { get; set; }
        public string? AuthorName { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
