using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webApiHost.Models;

namespace webApiHost.Data
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext (DbContextOptions<TasksDbContext> options)
            : base(options)
        {
        }

        public DbSet<webApiHost.Models.Task> Task { get; set; } = default!;
    }
}
