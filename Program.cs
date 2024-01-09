// NRules stuff
using NRules.Fluent;
using Exercises.CarTroubleshooting.Domain;
using Exercises.CarTroubleshooting.Rules;

namespace Exercises.CarTroubleshooting;

public static class Util
{
    // Ask yes/no question and return answer
    public static bool AskQuestion(string question)
    {
        Console.Write($"{question}? [y|n]: ");
        string answer = Console.ReadLine() ?? "";

        return answer.ToLower()[0] == 'y';
    }
}

public class Program
{
    public static void Main()
    {
        //Load rules
        var repository = new RuleRepository();
        repository.Load(x => x.From(typeof(CarSilentOnIgnitionRule).Assembly));

        //Compile rules
        var factory = repository.Compile();

        //Create a working session
        var session = factory.CreateSession();

        //Load domain model
        var car = new Car();

        car.IsSilentOnIgnition = Util.AskQuestion("Is the car silent when you turn the key");
        //Insert facts into rules engine's memory
        session.Insert(car);

        //Start match/resolve/act cycle
        session.Fire();
    }
}
