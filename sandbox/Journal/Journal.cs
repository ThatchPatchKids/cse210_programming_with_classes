/*
 * Copyright (c) 2024 Brother Keers, Brigham Young University Idaho
 */

public class Journal {

    // List to store Entry objects representing journal entries
    private List<Entry> entries = new List<Entry>();

    // InputOutput object for handling file input/output operations
    private InputOutput jio;

    // Default storage directory for journals
    private string storageDir = "journals";

    // Current journal's name (null if not loaded)
    private string journalName = null;

    // Constructor for the Journal class
    public Journal(string storageDir = "journals") {
        this.storageDir = storageDir;
        // Initialize InputOutput object with the specified storage directory
        jio = new InputOutput(storageDir);
    }

    // Method to create a new journal file
    private string CreateNewJournal() {
        Console.WriteLine("What is the filename for your new journal?");
        Console.Write("> ");
        string newJournal = Console.ReadLine().Trim();

        // Write an empty file for the new journal
        jio.WriteFile(newJournal, new List<string>());
        return newJournal;
    }

    // Method to display a specific entry
    public void DisplayEntry() {
        if (entries.Count == 0) {
            Console.WriteLine("There are no entries to print!");
            return;
        } 

        while(true) {
            Console.WriteLine("Which entry would you like to view?");
            ListEntries();
            Console.Write("> ");
            string choice = Console.ReadLine();

            int number;
            if (!int.TryParse(choice, out number)) {
                Console.WriteLine("You did not enter a valid number, please try again.");
                continue;
            }

            if (number < 1 || number > entries.Count) {
                Console.WriteLine($"Entry number {number} does not exist.");
                continue;
            }

            Console.WriteLine();
            // Display the chosen entry
            entries[number - 1].Display();
            break;
        }
    }

    // Method to display all entries
    public void DisplayAllEntries() {
        if (entries.Count == 0) {
            Console.WriteLine("There are no entries to print!");
            return;
        }
        Console.WriteLine();
        // Display all entries
        foreach (Entry entry in entries) {
            entry.Display();
        }
    }

    // Method to extract parts from a string representation of an entry
    private Dictionary<string, object> GetEntryParts(string entryData) {
        string[] parts = entryData.Split("<->");

        // Create a dictionary to hold the parts with named indexes
        Dictionary<string, object> entryObject = new Dictionary<string, object>();

        entryObject.Add("created", parts[0].Trim());
        entryObject.Add("prompt", parts[1].Trim());
        entryObject.Add("value", parts[2].Trim());

        return entryObject;
    }

    // Method to list entries with their respective indexes
    private void ListEntries() {
        for (int i = 0; i < entries.Count; i++) {
            Dictionary<string, object> entry = GetEntryParts(entries[i].ToString());
            string created = entry["created"] as string;
            string prompt = entry["prompt"] as string;
            Console.WriteLine($"[{i + 1}] {created} - {prompt}");
        }
    }

    // Method to load entries from a journal file
    private void LoadJournal() {
        string[] lines = jio.LoadFile(journalName);

        foreach (string line in lines) {
            Dictionary<string, object> entry = GetEntryParts(line);
            string created = entry["created"] as string;
            string prompt = entry["prompt"] as string;
            string value = entry["value"] as string;
            Entry savedEntry = new Entry(created, prompt, value);
            entries.Add(savedEntry);
        }
    }

    // Method to create a new entry and add it to the entries list
    public void NewEntry() {
        string created = DateTime.Now.ToString("yyyy-MM-dd");

        string prompt = PromptGenerator.GetPrompt();
        
        Console.WriteLine($"\n{prompt}");
        Console.Write("> ");
        string response = Console.ReadLine().Trim();

        // Create a new entry and add it to the entries list
        Entry entry = new Entry(created, prompt, response);
        entries.Add(entry);
        // Save the updated journal
        SaveJournal();
    }

    // Method to run the main application
    public void RunApp() {
        List<string> journals = jio.GetJournals();
        
        while(true) {
            if (journals.Count == 0) {
                // If there are no journals, create a new one
                string newJournal = CreateNewJournal();
                journals.Add(newJournal);
                journalName = newJournal;
                break;
            }

            Console.WriteLine("Which journal would you like to load?");
            for(int i = 0; i < journals.Count; i++) {
                Console.WriteLine($"[{i + 1}] {journals[i]}");
            }
            Console.Write("> ");
            string choice = Console.ReadLine().Trim();

            int number;
            if (!int.TryParse(choice, out number)) {
                Console.WriteLine("You did not enter a valid number, please try again.");
                continue;
            }

            if (number < 1 || number > journals.Count) {
                Console.WriteLine($"Journal number {number} does not exist.");
                continue;
            }

            // Set the current journal to the chosen journal
            journalName = journals[number - 1];
            break;
        }

        // Load entries from the chosen journal
        LoadJournal();

        while(true) {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Create New Entry");
            Console.WriteLine("[2] Update Entry");
            Console.WriteLine("[3] Display Entry");
            Console.WriteLine("[4] Display All Entries");
            Console.WriteLine("[5] New Journal");
            Console.WriteLine("[6] Change Journal");
            Console.WriteLine("[0] Exit App");
            Console.Write("> ");
            string choice = Console.ReadLine().Trim();

            if (choice == "1") {
                NewEntry();
            } else if (choice == "2") {
                UpdateEntry();
            } else if (choice == "3") {
                DisplayEntry();
            } else if (choice == "4") {
                DisplayAllEntries();
            } else if (choice == "5") {
                // Create a new journal; we need to reset the Journal App first
                string newJournal = CreateNewJournal();
                journalName = newJournal;
                entries = new List<Entry>();
                RunApp();
            } else if (choice == "6") {
                // Change the current journal; we need to reset the Journal App first
                journalName = null;
                entries = new List<Entry>();
                RunApp();
            } else if (choice == "0") {
                return;
            } else {
                Console.WriteLine("Invalid choice, please try again!\n\n");
            }
        }
    }

    // Method to save entries to the current journal file
    public void SaveJournal() {
        List<string> lines = new List<string>();

        foreach (Entry entry in entries) {
            // Convert entry to string representation and add to the list
            lines.Add(entry.StoreEntry());
        }

        // Write the list of entry strings to the journal file
        jio.WriteFile(journalName, lines);
    }

    // Method to update an existing entry
    public void UpdateEntry() {
        while(true) {
            Console.WriteLine("\nWhich entry would you like to change?");
            ListEntries();
            Console.Write("> ");
            string choice = Console.ReadLine();

            int number;
            if (!int.TryParse(choice, out number)) {
                Console.WriteLine("You did not enter a valid number, please try again.");
                continue;
            }

            if (number < 1 || number > entries.Count) {
                Console.WriteLine($"Entry number {number} does not exist.");
                continue;
            }

            // Get the prompt of the chosen entry
            Dictionary<string, object> entry = GetEntryParts(entries[number - 1].ToString());
            string prompt = entry["prompt"] as string;
            
            Console.WriteLine($"Please update your response to the following prompt:\n{prompt}");
            Console.Write("> ");
            string newEntry = Console.ReadLine().Trim();

            // Update the response of the chosen entry
            entries[number - 1].UpdateEntry(newEntry);
            break;
        }
        // Save the updated journal
        SaveJournal();
    }
}
