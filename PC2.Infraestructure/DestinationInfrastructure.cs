using Microsoft.EntityFrameworkCore;
using si730pc2u201624050.Infraestructure.Context;
using si730pc2u201624050.Infraestructure.Interfaces;
using si730pc2u201624050.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace si730pc2u201624050.Infraestructure
{
    public class DestinationInfrastructure : IDestinationInfrastructure
    {
        private readonly TravelersDbContext _context;

        public DestinationInfrastructure(TravelersDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Destination destination)
        {
            try
            {
                _context.Destinations.Add(destination);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Destination>> GetAll()
        {
            return await _context.Destinations.ToListAsync();
        }
    }
}
