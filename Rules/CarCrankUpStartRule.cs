using NRules.Fluent.Dsl;
using NRules.RuleModel;
using Exercises.CarTroubleshooting.Domain;

namespace Exercises.CarTroubleshooting.Rules;

public class CarCrankUpStartRule : Rule
{
    public override void Define()
    {
        Car car = new Car();
        
        When()
            .Match(() => car)
            .Match<Car>(c => c.IsStartingOnIgnition == Answer.Yes);

        Then()
            .Do(ctx => DoAction(ctx, car));
    }

    private static void DoAction(IContext ctx, Car car)
    {
        Console.WriteLine("Check spark plug connections.");
    }
}
