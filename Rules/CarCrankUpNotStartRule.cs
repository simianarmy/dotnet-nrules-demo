using NRules.Fluent.Dsl;
using NRules.RuleModel;
using Exercises.CarTroubleshooting.Domain;

namespace Exercises.CarTroubleshooting.Rules;

public class CarCrankUpNotStartRule : Rule
{
    public override void Define()
    {
        Car car = new Car();
        
        When()
            .Match(() => car)
            .Match<Car>(c => c.IsStartingOnIgnition == Answer.No &&
                    c.IsEngineDying == Answer.Unanswered);

        Then()
            .Do(ctx => DoAction(ctx, car));
    }

    private static void DoAction(IContext ctx, Car car)
    {
        car.IsEngineDying = Util.AskQuestion("Does the engine start and then die");
        ctx.Update(car);
    }
}
