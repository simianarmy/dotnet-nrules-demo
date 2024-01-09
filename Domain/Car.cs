namespace Exercises.CarTroubleshooting.Domain;

public class Car
{
    public Answer IsSilentOnIgnition { get; set; } = Answer.Unanswered;
    public Answer IsBatteryTerminalsCorroded { get; set; } = Answer.Unanswered;
    public Answer IsClickingNoise { get; set; } = Answer.Unanswered;
    public Answer IsStartingOnIgnition { get; set; } = Answer.Unanswered;
    public Answer IsEngineDying { get; set; } = Answer.Unanswered;
    public Answer hasFuelInjectionSystem { get; set; } = Answer.Unanswered;

    public override string ToString()
    {
        string s = ($"IsSilentOnIgnition: {IsSilentOnIgnition}\n");
        s += ($"IsBatteryTerminalsCorroded: {IsBatteryTerminalsCorroded}\n");
        s += ($"IsClickingNoise: {IsClickingNoise}\n");
        s += ($"IsStartingOnIgnition: {IsStartingOnIgnition}\n");
        s += ($"IsEngineDying: {IsEngineDying}\n");
        s += ($"hasFuelInjectionSystem: {hasFuelInjectionSystem}\n");

        return s;
    }
}

