using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APICodeFirstApproach.Models;

namespace APICodeFirstApproach.Data
{
    public class APICodeFirstApproachContext : DbContext
    {
        public APICodeFirstApproachContext (DbContextOptions<APICodeFirstApproachContext> options)
            : base(options)
        {
        }

        public DbSet<APICodeFirstApproach.Models.Emp> Emp { get; set; } = default!;
    }
}
