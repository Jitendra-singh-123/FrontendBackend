using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExerciseWebAPI.Models;

namespace ExerciseWebAPI.Data
{
    public class ExerciseWebAPIContext : DbContext
    {
        public ExerciseWebAPIContext (DbContextOptions<ExerciseWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ExerciseWebAPI.Models.Movie> Movie { get; set; } = default!;
    }
}
