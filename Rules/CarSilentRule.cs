using NRules.Fluent.Dsl;
using NRules.RuleModel;
using Exercises.CarTroubleshooting.Domain;

namespace Exercises.CarTroubleshooting.Rules;

public class CarSilentOnIgnitionRule : Rule
{
    public override void Define()
    {
        Car car = new Car();
        
        When()
            .Match(() => car)
            .Match<Car>(c => c.IsSilentOnIgnition == Answer.Yes && 
                    c.IsBatteryTerminalsCorroded == Answer.Unanswered);

        Then()
            .Do(ctx => PromptBatteryQuestion(ctx, car));
    }

    private static void PromptBatteryQuestion(IContext ctx, Car car)
    {
        car.IsBatteryTerminalsCorroded = Util.AskQuestion("Are the battery terminals corroded");
        ctx.Update(car);
    }
}
