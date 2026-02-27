using CoffeeShop.Application;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CoffeeShop.Application.BrewCoffee;

public sealed class BrewCoffeeCommandHandler
    : IRequestHandler<BrewCoffeeCommand, IResult>
{
    private readonly ICoffeeMachineState _state;
    private readonly IDateTimeProvider _clock;

    public BrewCoffeeCommandHandler(
        ICoffeeMachineState state,
        IDateTimeProvider clock)
    {
        _state = state;
        _clock = clock;
    }

    public Task<IResult> Handle(BrewCoffeeCommand request, CancellationToken cancellationToken)
    {
        var now = _clock.Now;

        // April 1st: return 418
        if (now.Month == 4 && now.Day == 1)
        {
            return Task.FromResult(Results.StatusCode(StatusCodes.Status418ImATeapot));
        }

        var count = _state.Increment();

        // Every 5th call: 503 (rule stays in Application layer)
        if (count % 5 == 0)
        {
            return Task.FromResult(Results.StatusCode(StatusCodes.Status503ServiceUnavailable));
        }

        var prepared = now.ToString("o"); // ISO-8601

        var response = new BrewCoffeeResponse
        {
            Message = "Your piping hot coffee is ready",
            Prepared = prepared
        };

        return Task.FromResult(Results.Ok(response));
    }
}
