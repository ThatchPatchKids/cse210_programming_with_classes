using System;

class Program
{
    static void Main(string[] args)
    {
        // Instantiate the PromptGenerator class.
        PromptGenerator promptGenerator = new PromptGenerator();
        
        // Instantiate the Journal class.
        Journal journal = new Journal();

        // Instantiate the MenuOptions class.
        MenuOptions menu = new MenuOptions();

        // Set the journaling variable to true.
        bool journaling = true;

        // Start the journal loop.
        while (journaling)
        {   
            // Call the DisplayOptions() method.
            menu.DisplayOptions();

            // Prompt the user to choose an option.
            Console.Write("What would you like to do? ");

            // 
            bool valid = false;
            //
            int option = 0;
            // 
            while (!valid)
            {
                try
                {
                    // 
                    option = int.Parse(Console.ReadLine());
                    valid = true;
                }
                catch
                {   
                    // 
                    Console.WriteLine("Sorry, choice must be an integer.");
                }
            }

            // Which option did they choose?
            switch (option)
            {   
                // Option: Write
                case 1:
                    // Instantiate the Entry class.
                    Entry entry = new Entry();

                    // Display a random prompt to the user.
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);

                    // 
                    if (prompt == "Thats all the prompts for today!")
                    {
                        break;
                    }

                    // Get the response from the user.
                    string response = Console.ReadLine();

                    // Get the date of the entry.
                    entry.GetDate();

                    // Call the SavePromptedResponse() method.
                    entry.SavePromptedResponse(prompt, response);

                    // Save the entry to the journal.
                    journal.AddEntry(entry);
                    break;

                // Option: Display
                case 2:
                    //  
                    journal.DisplayEntries();
                    break;

                // Option: Load
                case 3:
                    // 
                    journal.LoadFile();
                    break;

                // Option: Save
                case 4:
                    // 
                    journal.SaveFile();
                    break;

                // Option: Quit
                case 5:
                    journaling = false;
                    break;

                // Default case for miss input.
                default:
                    Console.WriteLine("Sorry, thats not an option.");
                    break;
            }
        }
    }
}