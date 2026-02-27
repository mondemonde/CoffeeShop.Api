using CoffeeShop.Application;

namespace CoffeeShop.Infrastructure;

public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}
