using si730pc2u201624050.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace si730pc2u201624050.Infraestructure.Interfaces
{
    public interface IDestinationInfrastructure
    {
        Task<bool> Create(Destination destination);
    }
}
