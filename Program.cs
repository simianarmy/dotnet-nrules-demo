// NRules stuff
using NRules;
using NRules.Fluent;
using Exercises.CarTroubleshooting.Domain;
using Exercises.CarTroubleshooting.Rules;

namespace Exercises.CarTroubleshooting;

public enum Answer {
    Unanswered,
    Yes,
    No
};

public static class Util
{
    // Ask yes/no question and return answer
    public static Answer AskQuestion(string question)
    {
        Console.Write($"{question}? [y|n]: ");
        string answer = Console.ReadLine() ?? "";

        return answer.ToLower()[0] == 'y' ? Answer.Yes : Answer.No;
    }
}

public class Program
{
    public static void Main()
    {
        //Load rules
        var repository = new RuleRepository();
        repository.Load(x => x.From(typeof(CarSilentOnIgnitionRule).Assembly));

        //Compile ruless
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
