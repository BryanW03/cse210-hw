/*
 * W05 Project: Mindfulness Program
 * Author: CSE 210 Student
 *
 * EXCEEDS CORE REQUIREMENTS IN THE FOLLOWING WAYS:
 *
 * 1. ADDITIONAL ACTIVITY: Added a "Gratitude Activity" (GratitudeActivity.cs) that walks
 *    the user through a guided gratitude meditation with timed reflection steps.
 *
 * 2. ACTIVITY LOG (saving/loading): An ActivityLog class records every completed activity
 *    (name, date/time, duration) to a text file (activity_log.txt). Users can view their
 *    full history from the menu. The file persists between sessions.
 *
 * 3. NO REPEAT PROMPTS/QUESTIONS: Both the ReflectionActivity and ListingActivity track
 *    which prompts/questions have been used and will not repeat one until all options
 *    in the list have been shown at least once (non-repeating shuffle behavior).
 *
 * 4. ENHANCED BREATHING ANIMATION: The BreathingActivity uses a visual block bar
 *    (█ characters) that shrinks as each breath countdown progresses, giving a more
 *    meaningful visual representation of the breath.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        ActivityLog log = new ActivityLog();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Program ===\n");
            Console.WriteLine("  1. Breathing Activity");
            Console.WriteLine("  2. Reflection Activity");
            Console.WriteLine("  3. Listing Activity");
            Console.WriteLine("  4. Gratitude Activity");
            Console.WriteLine("  5. View Activity Log");
            Console.WriteLine("  6. Quit");
            Console.Write("\nChoose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var breathing = new BreathingActivity();
                    breathing.Run();
                    log.Record(breathing.Name, breathing.Duration);
                    break;

                case "2":
                    var reflection = new ReflectionActivity();
                    reflection.Run();
                    log.Record(reflection.Name, reflection.Duration);
                    break;

                case "3":
                    var listing = new ListingActivity();
                    listing.Run();
                    log.Record(listing.Name, listing.Duration);
                    break;

                case "4":
                    var gratitude = new GratitudeActivity();
                    gratitude.Run();
                    log.Record(gratitude.Name, gratitude.Duration);
                    break;

                case "5":
                    log.DisplayLog();
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("\nThank you for taking time for mindfulness. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}