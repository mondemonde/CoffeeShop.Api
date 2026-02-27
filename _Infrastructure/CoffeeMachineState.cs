using CoffeeShop.Application;
using CoffeeShop.Domain;
using System.Collections.Concurrent;
using System.Threading;

namespace CoffeeShop.Infrastructure;

public class CoffeeMachineState : ICoffeeMachineState
{
    private readonly ConcurrentDictionary<int, CoffeeMachine> _machines = new();

    public CoffeeMachine GetOrCreate(int machineId)
    {
        return _machines.GetOrAdd(machineId, id => new CoffeeMachine(machineId));
    }

    public int Increment(int machineId)
    {
        var machine = GetOrCreate(machineId);
        return machine.Brew();
    }

    public int Current(int machineId)
    {
        var machine = GetOrCreate(machineId);
        return machine.TotalCoffeesBrewed;
    }
}
