using NRules.Fluent.Dsl;
using Exercises.CarTroubleshooting.Domain;

namespace Exercises.CarTroubleshooting.Rules;

public class CarSilentOnIgnitionRule : Rule
{
    public override void Define()
    {
        Car car = new Car();
        
        When()
            .Match(() => car)
            .Match<Car>(c => c.IsSilentOnIgnition == true);

        Then()
            .Do(_ => PromptBatteryQuestion(car));
    }

    private static void PromptBatteryQuestion(Car car)
    {
        car.IsBatteryTerminalsCorroded = Util.AskQuestion("Are the battery terminals corroded");
    }
}
