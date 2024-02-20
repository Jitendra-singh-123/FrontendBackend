using System;
using System.Collections.Generic;

namespace LoadOurOwnWebPage.Models
{
    public partial class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Salary { get; set; }
        public DateTime Doj { get; set; }
    }
}
