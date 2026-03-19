using System;
using System.Collections.Generic;
using System.IO;

// CREATIVITY & EXCEEDING REQUIREMENTS ADDITIONS:
// 1. Added a "Mood" tracking feature where the user inputs their mood for the day alongside their entry.
// 2. Implemented graceful error handling when trying to load a file that doesn't exist, preventing crashes.
// 3. Used a robust custom separator ("~~|~~") to safely save and load files without breaking if the user types commas.

public class Entry
{
    public string Date { get; set; }
    public string PromptText { get; set; }
    public string EntryText { get; set; }
    public string Mood { get; set; }

    public void Display()
    {
        Console.WriteLine($"Date: {Date} - Prompt: {PromptText}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine($"{EntryText}\n");
    }
}

public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something new I learned today?"
    };

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_prompts.Count);
        return _prompts[index];
    }
}

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is currently empty.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry.Date}~~|~~{entry.PromptText}~~|~~{entry.EntryText}~~|~~{entry.Mood}");
            }
        }
        Console.WriteLine("Journal saved successfully!\n");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("Error: File not found. Please check the filename and try again.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~~|~~");
            if (parts.Length == 4)
            {
                Entry newEntry = new Entry
                {
                    Date = parts[0],
                    PromptText = parts[1],
                    EntryText = parts[2],
                    Mood = parts[3]
                };
                _entries.Add(newEntry);
            }
        }
        Console.WriteLine("Journal loaded successfully!\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Console.Write("What is your current mood? ");
                    string mood = Console.ReadLine();

                    Entry newEntry = new Entry
                    {
                        Date = DateTime.Now.ToShortDateString(),
                        PromptText = prompt,
                        EntryText = response,
                        Mood = mood
                    };
                    myJournal.AddEntry(newEntry);
                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine();
                    myJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }
}