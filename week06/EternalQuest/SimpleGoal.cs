using System;

// A goal that can be marked complete once and awards points
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Constructor for loading from file
    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent(ref int score)
    {
        if (!_isComplete)
        {
            _isComplete = true;
            score += Points;
            Console.WriteLine($"  ✓ Goal completed! You earned {Points} points!");
        }
        else
        {
            Console.WriteLine("  This goal is already complete.");
        }
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDisplayString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description}) — {Points} pts";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Description},{Points},{_isComplete}";
    }
}
