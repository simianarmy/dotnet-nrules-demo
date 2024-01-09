using NRules.Fluent.Dsl;
using NRules.RuleModel;
using Exercises.CarTroubleshooting.Domain;

namespace Exercises.CarTroubleshooting.Rules;

public class CarNoClickingNoise : Rule
{
    public override void Define()
    {
        Car car = new Car();
        
        When()
            .Match(() => car)
            .Match<Car>(c => c.IsClickingNoise == Answer.No 
                    && c.IsStartingOnIgnition == Answer.Unanswered);

        Then()
            .Do(ctx => DoAction(ctx, car));
    }

    private static void DoAction(IContext ctx, Car car)
    {
        car.IsStartingOnIgnition = Util.AskQuestion("Does the car crank up but fail to start");
        ctx.Update(car);
    }
}
