using NRules.Fluent.Dsl;
using NRules.RuleModel;
using Exercises.CarTroubleshooting.Domain;

namespace Exercises.CarTroubleshooting.Rules;

public class CarNotSilentOnIgnitionRule : Rule
{
    public override void Define()
    {
        Car car = new Car();
        
        When()
            .Match(() => car)
            .Match<Car>(c => c.IsSilentOnIgnition == Answer.No && 
                    c.IsClickingNoise == Answer.Unanswered);

        Then()
            .Do(ctx => PromptQuestion(ctx, car));
    }

    private static void PromptQuestion(IContext ctx, Car car)
    {
        car.IsClickingNoise = Util.AskQuestion("Does the car make a clicking noise");
        ctx.Update(car);
    }
}
