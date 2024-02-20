using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using onetomanyWithoutFluentAPI.Models;

namespace onetomanyWithoutFluentAPI.Data
{
    public class onetomanyWithoutFluentAPIContext : DbContext
    {
        public onetomanyWithoutFluentAPIContext (DbContextOptions<onetomanyWithoutFluentAPIContext> options)
            : base(options)
        {
        }

        public DbSet<onetomanyWithoutFluentAPI.Models.Department> Department { get; set; } = default!;

        public DbSet<onetomanyWithoutFluentAPI.Models.Employee>? Employee { get; set; }
    }
}
