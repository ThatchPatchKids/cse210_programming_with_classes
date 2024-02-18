using System;
using System.Threading; // Add this namespace for Thread.Sleep

// Define the menu options using various declaration styles

// Option 1: Using the traditional List<string> syntax
// List<string> menuOptions = new List<string> { "A", "B", "C" };

// Option 2: Using the newer C# 9 syntax with target-typed new expression
// List<string> menuOptions = new() { "A", "B", "C" };

// Option 3: Using a string array - this is a concise way to define an array
// The elements are enclosed in curly braces and separated by commas
string[] menuOptions = { "Load Journal", "Add New Entry", "Display Entries" };

/**
 * Each of these options achieves the same result - creating a collection
 * of menu options. The choice between List<string> and string[] depends
 * on the specific needs of your program. Lists offer more flexibility,
 * while arrays are more concise for a fixed set of values like menu options.
 * The C# 9 syntax (Option 2) makes it even more concise when using lists.
 * In this case, a simple array suffices, providing readability and simplicity.
 */


while (true)
{
    // Display the menu
    Console.WriteLine("Menu:");
    for (int i = 0; i < menuOptions.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {menuOptions[i]}");
    }
    Console.WriteLine("0. Exit");

    // Get user input
    Console.Write("Enter your choice: ");
    string userInput = Console.ReadLine();

    // Validate and process user input
    if (int.TryParse(userInput, out int choice) && choice >= 0 && choice <= menuOptions.Length)
    {
        if (choice == 0)
        {
            // Exit the loop if the user chooses 0
            // NOTE: In a class context you would more likely return instead
            break;
        }
        else
        {
            // Process the selected option
            string selectedOption = menuOptions[choice - 1];
            Console.WriteLine($"You selected option {selectedOption}");

            // Add your logic for each option here
            // ...

            // Add a delay for better visibility
            Thread.Sleep(1000); // 1000 milliseconds (1 second)
        }
    }
    else
    {
        Console.WriteLine("Invalid choice. Please enter a valid option.");
    }

    Console.WriteLine();
}