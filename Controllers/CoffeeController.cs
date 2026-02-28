using CoffeeShop.Api.Models;
using CoffeeShop.Application.BrewCoffee;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MapsterMapper; // Add this using statement

namespace CoffeeShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper; // Inject IMapper

        public CoffeeController(IMediator mediator, IMapper mapper) // Add IMapper to constructor
        {
            _mediator = mediator;
            _mapper = mapper; // Assign mapper
        }

        [HttpGet("brew-coffee")]
        public async Task<ActionResult<BrewCoffeeResponse>> BrewCoffee([FromQuery] string? location = "New York")
        {
            var response = await _mediator.Send(new BrewCoffeeCommand(Location: location));

            switch (response.StatusCode)
            {
                case 418:
                    return StatusCode(418, _mapper.Map<BrewResultDTO>(response)); // Use Mapster for mapping
                case 503:
                    return StatusCode(503, null);
                default:
                    return Ok(_mapper.Map<BrewResultDTO>(response)); // Use Mapster for mapping
            }


        }
    }
}