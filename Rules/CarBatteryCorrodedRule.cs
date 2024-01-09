using NRules.Fluent.Dsl;
using Exercises.CarTroubleshooting.Domain;

namespace Exercises.CarTroubleshooting.Rules;

public class CarBatteryCorrodedRule : Rule
{
    public override void Define()
    {
        Car car = new Car();
        
        When()
            .Match(() => car)
            .Match<Car>(c => c.IsBatteryTerminalsCorroded == Answer.Yes);

        Then()
            .Do(ctx => DoAction(car));
    }

    private static void DoAction(Car car)
    {
        Console.WriteLine("Clean terminals and try starting again");
    }
}
