using CoffeeShop.Api.Models;
using CoffeeShop.Application.BrewCoffee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoffeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("brew-coffee")]
        public async Task<ActionResult<BrewCoffeeResponse>> BrewCoffee()
        {
            var response = await _mediator.Send(new BrewCoffeeCommand());

            switch (response.StatusCode)
            {
                case 418:
                    return StatusCode(418, new BrewResultDTO(response));
                case 503:
                    return StatusCode(503, null);
                default:
                    return Ok(new BrewResultDTO(response));
            }


        }
    }
}