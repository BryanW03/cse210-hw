using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _usedPrompts;
    private List<string> _usedQuestions;

    public ReflectionActivity()
        : base("Reflection Activity",
               "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _usedPrompts = new List<string>();
        _usedQuestions = new List<string>();
    }

       private string GetRandomItem(List<string> pool, List<string> used)
    {
        if (used.Count == pool.Count)
            used.Clear();

        Random rand = new Random();
        string item;
        do
        {
            item = pool[rand.Next(pool.Count)];
        } while (used.Contains(item));

        used.Add(item);
        return item;
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomItem(_prompts, _usedPrompts);
        Console.WriteLine($"\n--- Reflect on this ---\n{prompt}\n");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomItem(_questions, _usedQuestions);
            Console.Write($"\n> {question} ");
            ShowSpinner(8);
        }

        DisplayEndingMessage();
    }
}
