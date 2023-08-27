using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using si730pc2u201624050.API.Input;
using si730pc2u201624050.API.Response;
using si730pc2u201624050.Domain.Interfaces;
using si730pc2u201624050.Infraestructure.Models;

namespace si730pc2u201624050.API.Controllers
{
    [Route("api/v1/destinations")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationDomain _destinationDomain;
        private readonly IMapper _mapper;

        public DestinationController(IDestinationDomain destinationDomain, IMapper mapper)
        {
            _destinationDomain = destinationDomain;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDestination(DestinationInput input)
        {
            if (ModelState.IsValid)
            {

                var destination = _mapper.Map<DestinationInput, Destination>(input);
                var isCreaded = await _destinationDomain.Create(destination);
                if (!isCreaded) return BadRequest("Ya existe un destino con ese nombre");
                return Created($"/api/v1/destinations/{destination.Id}", destination);
            }
            return BadRequest("Formato invalido");
        }

        [HttpGet]
        public async Task<List<DestinationResponse>> GetAll()
        {
            var destinations = await _destinationDomain.GetAll();
            var result = _mapper.Map<List<Destination>, List<DestinationResponse>>(destinations);
            return result;
        }
    }
}
