using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using one_to_oneEFWithoutFluentAPI.Models;

namespace one_to_oneEFWithoutFluentAPI.Data
{
    public class one_to_oneEFWithoutFluentAPIContext : DbContext
    {
        public one_to_oneEFWithoutFluentAPIContext (DbContextOptions<one_to_oneEFWithoutFluentAPIContext> options)
            : base(options)
        {
        }

        public DbSet<one_to_oneEFWithoutFluentAPI.Models.Author> Author { get; set; } = default!;

        public DbSet<one_to_oneEFWithoutFluentAPI.Models.Biography>? Biography { get; set; }
    }
}
