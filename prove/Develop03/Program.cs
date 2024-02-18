using System;

class Program
{
    static void Main(string[] args)
    {
        Reference scriptureReference = new Reference("Proverbs", "3", "5-6", "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        bool memorizing = true;

        while (memorizing)
        {
            scriptureReference.DisplayScripture();
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            string response = Console.ReadLine();

            if (response == "quit" || scriptureReference.IsHidden())
            {
                memorizing = false;
            }
            
            else
            {
                Console.Clear();
            }
        }
    }
}