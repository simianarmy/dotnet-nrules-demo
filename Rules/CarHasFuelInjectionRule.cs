using NRules.Fluent.Dsl;
using NRules.RuleModel;
using Exercises.CarTroubleshooting.Domain;

namespace Exercises.CarTroubleshooting.Rules;

public class CarHasFuelInjectionRule : Rule
{
    public override void Define()
    {
        Car car = new Car();
        
        When()
            .Match(() => car)
            .Match<Car>(c => c.hasFuelInjectionSystem == Answer.Yes);

        Then()
            .Do(ctx => DoAction(ctx, car));
    }

    private static void DoAction(IContext ctx, Car car)
    {
        Console.WriteLine("Get it in for service.");
    }
}
