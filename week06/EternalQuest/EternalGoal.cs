using System;

// A goal that never completes — earns points each time it's recorded
public class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _timesRecorded = 0;
    }

    // Constructor for loading from file
    public EternalGoal(string name, string description, int points, int timesRecorded)
        : base(name, description, points)
    {
        _timesRecorded = timesRecorded;
    }

    public override void RecordEvent(ref int score)
    {
        _timesRecorded++;
        score += Points;
        Console.WriteLine($"  ✓ Event recorded! You earned {Points} points! (Total times: {_timesRecorded})");
    }

    // Eternal goals are never complete
    public override bool IsComplete() => false;

    public override string GetDisplayString()
    {
        return $"[∞] {Name} ({Description}) — {Points} pts each | Recorded {_timesRecorded} times";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Description},{Points},{_timesRecorded}";
    }
}
