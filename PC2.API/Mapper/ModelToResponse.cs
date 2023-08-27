using AutoMapper;
using si730pc2u201624050.API.Response;
using si730pc2u201624050.Infraestructure.Models;

namespace si730pc2u201624050.API.Mapper
{
    public class ModelToResponse : Profile
    {
        public ModelToResponse()
        {
            CreateMap<Destination, DestinationResponse>();
        }
    }
}
