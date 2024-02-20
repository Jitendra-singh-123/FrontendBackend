using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIExercise.Models;

namespace WebAPIExercise.Data
{
    public class WebAPIExerciseContext : DbContext
    {
        public WebAPIExerciseContext (DbContextOptions<WebAPIExerciseContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPIExercise.Models.Movies> Movies { get; set; } = default!;
    }
}
