
using CoffeeShop.Domain;

namespace CoffeeShop.Application;

public interface ICoffeeMachineState
{
    CoffeeMachine GetOrCreate(int machineId = 1);
    int Increment(int machineId = 1);
    //int Current(int machineId = 1);
}