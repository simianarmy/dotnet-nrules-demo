using NRules.Fluent.Dsl;
using NRules.RuleModel;
using Exercises.CarTroubleshooting.Domain;

namespace Exercises.CarTroubleshooting.Rules;

public class CarNotHasFuelInjectionRule : Rule
{
    public override void Define()
    {
        Car car = new Car();
        
        When()
            .Match(() => car)
            .Match<Car>(c => c.hasFuelInjectionSystem == Answer.No);

        Then()
            .Do(ctx => DoAction(ctx, car));
    }

    private static void DoAction(IContext ctx, Car car)
    {
        Console.WriteLine("Check to ensure the choke is opening and closing.");
    }
}
