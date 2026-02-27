namespace CoffeeShop.Application;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
}
