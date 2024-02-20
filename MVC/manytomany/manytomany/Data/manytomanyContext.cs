using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using manytomany.Models;

namespace manytomany.Data
{
    public class manytomanyContext : DbContext
    {
        public manytomanyContext (DbContextOptions<manytomanyContext> options)
            : base(options)
        {
        }

        public DbSet<manytomany.Models.Course> Course { get; set; } = default!;

        public DbSet<manytomany.Models.Student>? Student { get; set; }
    }
}
