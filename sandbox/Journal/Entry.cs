/*
 * Copyright (c) 2024 Brother Keers, Brigham Young University Idaho
 */

// Represents a single entry within a journal
class Entry(string created, string prompt, string entry) {

    // Properties to store the entry's data
    private string created = created; // Date the entry was created
    private string entry = entry; // The main content of the entry
    private string prompt = prompt; // The prompt that inspired the entry

    // Displays the entry in a formatted way to the console
    public void Display() {
        Console.WriteLine($"{created} - {prompt}\n{entry}\n");
    }

    // Formats the entry into a string suitable for storage
    public string StoreEntry() {
        return $"{created} <-> {prompt} <-> {entry}"; // Use <-> as a delimiter
    }

    // Overrides the ToString method to return the stored string representation
    public override string ToString() {
        return StoreEntry();
    }

    // Updates the entry's content with a new value
    public void UpdateEntry(string newEntry) {
        entry = newEntry;
    }
}
