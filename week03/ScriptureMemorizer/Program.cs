// Program.cs - Scripture Memorizer (W03 Project)
//
// EXCEEDS CORE REQUIREMENTS:
// 1. Scripture Library: Uses a ScriptureLibrary class with multiple scriptures,
//    selecting one at random each time the program runs.
// 2. Smart Word Hiding (Stretch Challenge): Only hides words that are NOT yet
//    hidden, so no turns are wasted hiding already-hidden words.
// 3. Hides 3 words per Enter press.

using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();

        library.AddScripture(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life"
        ));
        library.AddScripture(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all your heart and lean not on your own understanding in all your ways submit to him and he will make your paths straight"
        ));
        library.AddScripture(new Scripture(
            new Reference("Philippians", 4, 13),
            "I can do all this through him who gives me strength"
        ));
        library.AddScripture(new Scripture(
            new Reference("Romans", 8, 28),
            "And we know that in all things God works for the good of those who love him who have been called according to his purpose"
        ));
        library.AddScripture(new Scripture(
            new Reference("Psalm", 23, 1, 3),
            "The Lord is my shepherd I lack nothing He makes me lie down in green pastures he leads me beside quiet waters he refreshes my soul"
        ));
        library.AddScripture(new Scripture(
            new Reference("Isaiah", 41, 10),
            "So do not fear for I am with you do not be dismayed for I am your God I will strengthen you and help you I will uphold you with my righteous right hand"
        ));
        library.AddScripture(new Scripture(
            new Reference("Joshua", 1, 9),
            "Have I not commanded you Be strong and courageous Do not be afraid do not be discouraged for the Lord your God will be with you wherever you go"
        ));

        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden! Great job practicing!");
                break;
            }

            Console.Write("Press Enter to hide more words, or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }
    }
}