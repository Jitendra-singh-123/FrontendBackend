using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapiexerciseEF.Models;

namespace webapiexerciseEF.Models
{
    public class webapiexerciseEFContext : DbContext
    {
        public webapiexerciseEFContext(DbContextOptions<webapiexerciseEFContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Author { get; set; } = default!;

        public DbSet<webapiexerciseEF.Models.Book>? Book { get; set; }

        public DbSet<webapiexerciseEF.Models.Genre>? Genre { get; set; }
    }
}
