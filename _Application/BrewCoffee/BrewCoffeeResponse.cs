namespace CoffeeShop.Application.BrewCoffee;

public sealed class BrewCoffeeResponse
{
    public required string Message { get; init; }
    public required string Prepared { get; init; }
}
