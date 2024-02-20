using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoggingInWebAPI;

namespace LoggingInWebAPI.Data
{
    public class LoggingInWebAPIContext : DbContext
    {
        public LoggingInWebAPIContext (DbContextOptions<LoggingInWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<LoggingInWebAPI.Player> Player { get; set; } = default!;
    }
}
