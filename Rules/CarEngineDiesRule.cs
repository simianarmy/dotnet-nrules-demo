using NRules.Fluent.Dsl;
using NRules.RuleModel;
using Exercises.CarTroubleshooting.Domain;

namespace Exercises.CarTroubleshooting.Rules;

public class CarEngineDiesRule : Rule
{
    public override void Define()
    {
        Car car = new Car();
        
        When()
            .Match(() => car)
            .Match<Car>(c => c.IsEngineDying == Answer.Yes &&
                    c.hasFuelInjectionSystem == Answer.Unanswered);

        Then()
            .Do(ctx => DoAction(ctx, car));
    }

    private static void DoAction(IContext ctx, Car car)
    {
        car.hasFuelInjectionSystem = Util.AskQuestion("Does your car have fuel injection");
        ctx.Update(car);
    }
}
