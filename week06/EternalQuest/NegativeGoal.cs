using System;

// EXCEEDS REQUIREMENTS: A "negative goal" — recording it subtracts points (tracks bad habits)
public class NegativeGoal : Goal
{
    private int _timesOccurred;

    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _timesOccurred = 0;
    }

    // Constructor for loading from file
    public NegativeGoal(string name, string description, int points, int timesOccurred)
        : base(name, description, points)
    {
        _timesOccurred = timesOccurred;
    }

    public override void RecordEvent(ref int score)
    {
        _timesOccurred++;
        score -= Points;
        Console.WriteLine($"  ✗ Bad habit recorded. You lost {Points} points. (Occurred {_timesOccurred} times — try to break this habit!)");
        if (score < 0) score = 0;
    }

    // Negative goals are never "complete" — you just try to reduce them
    public override bool IsComplete() => false;

    public override string GetDisplayString()
    {
        return $"[✗] {Name} ({Description}) — -{Points} pts each | Occurred {_timesOccurred} times";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{Name},{Description},{Points},{_timesOccurred}";
    }
}
