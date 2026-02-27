namespace CoffeeShop.Domain;

public sealed class CoffeeMachine
{
    public int TotalCoffeesBrewed { get; private set; }

    public CoffeeMachine(int initialCount = 0)
    {
        TotalCoffeesBrewed = initialCount;
    }

    public int Brew()
    {
        TotalCoffeesBrewed++;
        Console.WriteLine($"Brewed a cup of coffee. Total brewed: {TotalCoffeesBrewed}");
        return TotalCoffeesBrewed;
    }
}
