using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppEntity.Models;

namespace WebAppEntity.Data
{
    public class WebAppEntityContext : DbContext
    {
        public WebAppEntityContext (DbContextOptions<WebAppEntityContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppEntity.Models.FilmIndustry> FilmIndustry { get; set; } = default!;
    }
}
