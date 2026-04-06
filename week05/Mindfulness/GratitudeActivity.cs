using System;
using System.Collections.Generic;
using System.Threading;

public class GratitudeActivity : Activity
{
    public GratitudeActivity()
        : base("Gratitude Activity",
               "This activity will guide you through a short gratitude meditation. Focusing on what you are grateful for has been shown to increase happiness and reduce stress.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        string[] steps =
        {
            "Close your eyes and take a slow, deep breath.",
            "Think of one person in your life you are grateful for.",
            "Picture their face and recall a moment they made you smile.",
            "Now think of one thing about YOUR life you appreciate.",
            "Let that gratitude fill your chest — sit with it.",
            "Think of one small thing that happened today that was good.",
            "Take one final deep breath and carry this feeling with you."
        };

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        int stepIndex = 0;

        while (DateTime.Now < endTime)
        {
            string step = steps[stepIndex % steps.Length];
            Console.WriteLine($"\n  💛 {step}");
            Console.Write("     ");
            ShowSpinner(6);
            stepIndex++;
        }

        DisplayEndingMessage();
    }
}
