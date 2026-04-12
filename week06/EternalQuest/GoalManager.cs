using System;
using System.Collections.Generic;
using System.IO;

// Manages the list of goals and user score
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string _playerName;

    public GoalManager(string playerName)
    {
        _goals = new List<Goal>();
        _score = 0;
        _playerName = playerName;
    }

    public int Score => _score;
    public string PlayerName => _playerName;

    // EXCEEDS REQUIREMENTS: Level and title based on score
    public string GetLevel()
    {
        if (_score < 500)        return "Level 1 - Apprentice Adventurer";
        else if (_score < 1500)  return "Level 2 - Brave Squire";
        else if (_score < 3000)  return "Level 3 - Skilled Knight";
        else if (_score < 6000)  return "Level 4 - Heroic Paladin";
        else if (_score < 10000) return "Level 5 - Legendary Champion";
        else                     return "Level 6 - Eternal Quest Master ⭐";
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\n  ╔═══════════════════════════════════════╗");
        Console.WriteLine($"  ║  Player : {_playerName,-28} ║");
        Console.WriteLine($"  ║  Score  : {_score,-28} ║");
        Console.WriteLine($"  ║  {GetLevel(),-37} ║");
        Console.WriteLine($"  ╚═══════════════════════════════════════╝");
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("  No goals yet. Create some to get started!");
            return;
        }

        Console.WriteLine("\n  --- Your Goals ---");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDisplayString()}");
        }
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("  No goals to record. Add some first!");
            return;
        }

        DisplayGoals();
        Console.Write("\n  Enter goal number to record: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= _goals.Count)
        {
            _goals[index - 1].RecordEvent(ref _score);
        }
        else
        {
            Console.WriteLine("  Invalid selection.");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_playerName);
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"  Goals saved to {filename}");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("  Save file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();
        _playerName = lines[0];
        _score = int.Parse(lines[1]);

        for (int i = 2; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');
            string type = parts[0];
            string[] data = parts[1].Split(',');

            Goal goal = null;

            switch (type)
            {
                case "SimpleGoal":
                    goal = new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3]));
                    break;
                case "EternalGoal":
                    goal = new EternalGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]));
                    break;
                case "ChecklistGoal":
                    goal = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]),
                                             int.Parse(data[4]), int.Parse(data[5]));
                    break;
                case "NegativeGoal":
                    goal = new NegativeGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]));
                    break;
            }

            if (goal != null)
                _goals.Add(goal);
        }

        Console.WriteLine($"  Loaded {_goals.Count} goals for {_playerName}. Score: {_score}");
    }
}
