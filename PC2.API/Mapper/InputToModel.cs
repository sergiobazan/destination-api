using AutoMapper;
using si730pc2u201624050.API.Input;
using si730pc2u201624050.Infraestructure.Models;

namespace si730pc2u201624050.API.Mapper
{
    public class InputToModel : Profile
    {
        public InputToModel()
        {
            CreateMap<DestinationInput, Destination>(); 
        }
    }
}
