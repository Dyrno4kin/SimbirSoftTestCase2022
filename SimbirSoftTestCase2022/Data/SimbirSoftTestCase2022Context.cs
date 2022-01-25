#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimbirSoftTestCase2022.Models;

namespace SimbirSoftTestCase2022.Data
{
    public class SimbirSoftTestCase2022Context : DbContext
    {
        public SimbirSoftTestCase2022Context (DbContextOptions<SimbirSoftTestCase2022Context> options)
            : base(options)
        {
        }

        public DbSet<SimbirSoftTestCase2022.Models.Movie> Movie { get; set; }
    }
}
