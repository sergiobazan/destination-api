using Microsoft.EntityFrameworkCore;
using si730pc2u201624050.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace si730pc2u201624050.Infraestructure.Context
{
    public class TravelersDbContext : DbContext
    {
        public TravelersDbContext(DbContextOptions<TravelersDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Destination> Destinations { get; set; }
    }
}
