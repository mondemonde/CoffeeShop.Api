using MediatR;
using Microsoft.AspNetCore.Http;

namespace CoffeeShop.Application.BrewCoffee;

public sealed record BrewCoffeeCommand(int MachineId = 1) : IRequest<IResult>;
