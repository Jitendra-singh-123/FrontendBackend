using System;
using System.Collections.Generic;

namespace DataBaseFirstApproachAPI.Models
{
    public partial class Course
    {
        public int Cid { get; set; }
        public string Cname { get; set; } = null!;
        public string Ctech { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
