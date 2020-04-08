using AdoptADrain.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptADrain.Services
{
    public class AdoptADrainDataContext : DbContext
    {

        public AdoptADrainDataContext(DbContextOptions options)
         : base(options)
        {
        }
        public DbSet<StormDrain> StormDrain { get; set; }
    }
}
