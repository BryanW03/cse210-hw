using System;
using System.Collections.Generic;
using System.IO;

public class ActivityLog
{
    private string _logFile = "activity_log.txt";
    private List<string> _sessionLog = new List<string>();

    public void Record(string activityName, int durationSeconds)
    {
        string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm} | {activityName} | {durationSeconds}s";
        _sessionLog.Add(entry);

        
        try
        {
            File.AppendAllText(_logFile, entry + Environment.NewLine);
        }
        catch { /* silently skip if file write fails */ }
    }

    public void DisplayLog()
    {
        Console.Clear();
        Console.WriteLine("=== Activity Log ===\n");

        if (!File.Exists(_logFile))
        {
            Console.WriteLine("No activities logged yet.");
        }
        else
        {
            string[] lines = File.ReadAllLines(_logFile);
            if (lines.Length == 0)
            {
                Console.WriteLine("No activities logged yet.");
            }
            else
            {
                foreach (string line in lines)
                    Console.WriteLine("  " + line);
            }
        }

        Console.WriteLine("\nPress Enter to return to menu...");
        Console.ReadLine();
    }
}
