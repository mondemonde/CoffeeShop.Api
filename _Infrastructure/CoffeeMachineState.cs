using System.Threading;
using CoffeeShop.Application;
using CoffeeShop.Domain;

namespace CoffeeShop.Infrastructure;

public class CoffeeMachineState : ICoffeeMachineState
{
    private int _counter = 0;

    public CoffeeMachine Machine { get; }

    public CoffeeMachineState()
    {
        Machine = new CoffeeMachine();
    }

    public int Current => _counter;

    public int Increment()
    {
        var newValue = Interlocked.Increment(ref _counter);
        Machine.Brew();
        return newValue;
    }
}
