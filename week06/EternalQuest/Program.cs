// EXCEEDS REQUIREMENTS:
// 1. Leveling System: Players earn titles/levels as their score increases,
//    ranging from "Apprentice Adventurer" to "Eternal Quest Master".
//    Levels unlock at 500, 1500, 3000, 6000, and 10000 points.
//
// 2. Negative Goals: A fourth goal type (NegativeGoal) allows users to
//    track bad habits they want to break. Recording one subtracts points,
//    encouraging the user to avoid those behaviors.
//
// 3. Visual Polish: Score display uses a formatted ASCII box showing the
//    player's name, score, and current level title for a "gamified" feel.
// =============================================================================

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("╔══════════════════════════════════╗");
        Console.WriteLine("║       ETERNAL QUEST PROGRAM      ║");
        Console.WriteLine("╚══════════════════════════════════╝");

        Console.Write("\nEnter your name, adventurer: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) name = "Adventurer";

        GoalManager manager = new GoalManager(name);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n========== MAIN MENU ==========");
            Console.WriteLine("  1. Display Score & Level");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Create New Goal");
            Console.WriteLine("  4. Record Event");
            Console.WriteLine("  5. Save Goals");
            Console.WriteLine("  6. Load Goals");
            Console.WriteLine("  7. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.DisplayScore();
                    break;

                case "2":
                    manager.DisplayGoals();
                    break;

                case "3":
                    CreateGoal(manager);
                    break;

                case "4":
                    manager.RecordEvent();
                    break;

                case "5":
                    Console.Write("  Enter filename to save (e.g. goals.txt): ");
                    string saveFile = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(saveFile))
                        manager.SaveGoals(saveFile);
                    break;

                case "6":
                    Console.Write("  Enter filename to load (e.g. goals.txt): ");
                    string loadFile = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(loadFile))
                        manager.LoadGoals(loadFile);
                    break;

                case "7":
                    Console.WriteLine("\nFarewell, adventurer! Keep pursuing your Eternal Quest!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("  Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\n  --- Goal Types ---");
        Console.WriteLine("  1. Simple Goal     (complete once for points)");
        Console.WriteLine("  2. Eternal Goal    (earn points every time, never finishes)");
        Console.WriteLine("  3. Checklist Goal  (complete X times for points + bonus)");
        Console.WriteLine("  4. Negative Goal   (bad habit — lose points when recorded)");
        Console.Write("  Choose goal type: ");

        string typeChoice = Console.ReadLine();

        Console.Write("  Goal name: ");
        string name = Console.ReadLine();

        Console.Write("  Short description: ");
        string description = Console.ReadLine();

        Console.Write("  Points (per event): ");
        if (!int.TryParse(Console.ReadLine(), out int points) || points <= 0)
        {
            Console.WriteLine("  Invalid points value.");
            return;
        }

        switch (typeChoice)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, description, points));
                Console.WriteLine("  ✓ Simple goal created!");
                break;

            case "2":
                manager.AddGoal(new EternalGoal(name, description, points));
                Console.WriteLine("  ✓ Eternal goal created!");
                break;

            case "3":
                Console.Write("  How many times must this be completed? ");
                if (!int.TryParse(Console.ReadLine(), out int required) || required <= 0)
                {
                    Console.WriteLine("  Invalid value.");
                    return;
                }
                Console.Write("  Bonus points on full completion: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
                {
                    Console.WriteLine("  Invalid bonus.");
                    return;
                }
                manager.AddGoal(new ChecklistGoal(name, description, points, required, bonus));
                Console.WriteLine("  ✓ Checklist goal created!");
                break;

            case "4":
                manager.AddGoal(new NegativeGoal(name, description, points));
                Console.WriteLine("  ✓ Negative goal created! Avoid this habit to protect your score.");
                break;

            default:
                Console.WriteLine("  Invalid goal type.");
                break;
        }
    }
}