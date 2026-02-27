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
            return Ok(response);
        }
    }
}