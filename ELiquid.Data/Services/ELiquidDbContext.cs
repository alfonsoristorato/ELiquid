using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELiquid.Data.Models;

namespace ELiquid.Data.Services
{
    public class ELiquidDbContext : DbContext
    {
        public DbSet<ElecLiquid> ElecLiquids { get; set; }

    }
}
