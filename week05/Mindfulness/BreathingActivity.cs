using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        bool breatheIn = true;

        while (DateTime.Now < endTime)
        {
            if (breatheIn)
            {
                Console.Write("Breathe in... ");
                ShowBreathingCountdown(4);
            }
            else
            {
                Console.Write("Breathe out... ");
                ShowBreathingCountdown(6);
            }
            Console.WriteLine();
            breatheIn = !breatheIn;
        }

        DisplayEndingMessage();
    }

  
    private void ShowBreathingCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string bar = new string('█', i);
            Console.Write($"[{bar,-6}] {i}");
            Thread.Sleep(1000);
         
            int charsToErase = bar.Length + 5; // "[" + bar + "] " + digit(s)
            for (int c = 0; c < charsToErase; c++)
                Console.Write("\b \b");
        }
    }
}
