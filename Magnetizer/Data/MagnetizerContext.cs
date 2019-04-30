using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Magnetizer.Models
{
    public class MagnetizerContext : DbContext
    {
        public MagnetizerContext (DbContextOptions<MagnetizerContext> options)
            : base(options)
        {
        }

        public DbSet<Magnetizer.Models.Product> Product { get; set; }
    }
}
