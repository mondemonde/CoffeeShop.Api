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

        var thisMachine = _state.GetOrCreate(request.MachineId);
        var totalForMachineToBrew = thisMachine.JustIncreaseAge();

        // April 1st: return 418 for any machine
        if (now.Month == 4 && now.Day == 1)
        {
            return Task.FromResult(Results.StatusCode(StatusCodes.Status418ImATeapot));
        }

       

        // Every 5th coffee **per machine** -> 503
        if (thisMachine.Age % 5 == 0)
        {
            Console.WriteLine($"Machine {request.MachineId} will have total to brew {totalForMachineToBrew} coffees, returning 503");
            return Task.FromResult(Results.StatusCode(StatusCodes.Status503ServiceUnavailable));

        }

        var totalForMachine = _state.Increment(request.MachineId);
        var prepared = now.ToString("o");

        var response = new BrewCoffeeResponse
        {
            Message = "Your piping hot coffee is ready",
            Prepared = prepared
          
        };

        return Task.FromResult(Results.Ok(response));
    }
}
