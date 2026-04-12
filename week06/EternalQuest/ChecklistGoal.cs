using System;

// A goal that must be completed a certain number of times, with a bonus on completion
public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _requiredTimes;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int requiredTimes, int bonusPoints)
        : base(name, description, points)
    {
        _timesCompleted = 0;
        _requiredTimes = requiredTimes;
        _bonusPoints = bonusPoints;
    }

    // Constructor for loading from file
    public ChecklistGoal(string name, string description, int points, int requiredTimes, int bonusPoints, int timesCompleted)
        : base(name, description, points)
    {
        _requiredTimes = requiredTimes;
        _bonusPoints = bonusPoints;
        _timesCompleted = timesCompleted;
    }

    public override void RecordEvent(ref int score)
    {
        if (IsComplete())
        {
            Console.WriteLine("  This checklist goal is already fully complete!");
            return;
        }

        _timesCompleted++;
        score += Points;
        Console.WriteLine($"  ✓ Progress recorded! You earned {Points} points! ({_timesCompleted}/{_requiredTimes})");

        if (_timesCompleted == _requiredTimes)
        {
            score += _bonusPoints;
            Console.WriteLine($"  🎉 GOAL COMPLETE! Bonus of {_bonusPoints} points awarded!");
        }
    }

    public override bool IsComplete() => _timesCompleted >= _requiredTimes;

    public override string GetDisplayString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description}) — {Points} pts each + {_bonusPoints} bonus | Completed {_timesCompleted}/{_requiredTimes} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Description},{Points},{_requiredTimes},{_bonusPoints},{_timesCompleted}";
    }
}
