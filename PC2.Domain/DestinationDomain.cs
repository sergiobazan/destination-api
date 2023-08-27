using Microsoft.EntityFrameworkCore;
using si730pc2u201624050.Infraestructure.Context;
using si730pc2u201624050.Domain.Interfaces;
using si730pc2u201624050.Infraestructure.Interfaces;
using si730pc2u201624050.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace si730pc2u201624050.Domain
{
    public class DestinationDomain : IDestinationDomain
    {
        private readonly IDestinationInfrastructure _destinationInfrastructure;
        private readonly TravelersDbContext _travelersDbContext;

        public DestinationDomain(IDestinationInfrastructure destinationInfrastructure, TravelersDbContext travelersDbContext)
        {
            _destinationInfrastructure = destinationInfrastructure;
            _travelersDbContext = travelersDbContext;
        }
        public async Task<bool> Create(Destination destination)
        {
            var destinationExists = await _travelersDbContext
                                            .Destinations
                                            .FirstOrDefaultAsync(d => d.Name == destination.Name);
            if (destinationExists != null) return false;
            return await _destinationInfrastructure.Create(destination);
        }
    }
}
