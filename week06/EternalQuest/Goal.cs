using System;

// Base class for all goal types
public abstract class Goal
{
    // Encapsulation: private member variables
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Properties for access
    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    // Polymorphism: derived classes override these methods
    public abstract void RecordEvent(ref int score);
    public abstract bool IsComplete();
    public abstract string GetDisplayString();
    public abstract string GetStringRepresentation();
}
