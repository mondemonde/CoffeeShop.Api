using CoffeeShop.Domain;

namespace CoffeeShop.Application;

public interface ICoffeeMachineState
{
    CoffeeMachine Machine { get; }
    int Increment();
    int Current { get; }
}
