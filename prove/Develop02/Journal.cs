using System;
using System.Text.Json;


public class Journal 
{
    // Member variables/ Attributes:

    // List of entries. 
    public List<Entry> _entries = new List<Entry>();

    // String to store the file name where the Journal entries will be stored.
    public string _fileName = "";

    // Member functions/ Methods:
    
    // Constructor method
    public Journal()
    {
    }

    //
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // 
    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    //
    public void LoadFile()
    {
        //
        Console.WriteLine("What is the filename?");
        _fileName = Console.ReadLine();

        // This doesn't work, it doesn't load the first line from the file but loads the rest, why?
        try
        {
            if (File.Exists(_fileName))
            {
                // _entries.Clear();
                using (StreamReader reader = new StreamReader(_fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        string entryString = reader.ReadLine();
                        string[] parts = entryString.Split(',');
                        if (parts.Length == 2)
                        {
                            Dictionary<string, string> readDict = JsonSerializer.Deserialize<Dictionary<string, string>>(parts[0]);
                            Entry entry = new Entry
                            {
                                _promptedResponses = readDict,
                                _date = parts[1]
                            };
                            _entries.Add(entry);
                        }
                    }
                }
            }

            else
            {
                Console.WriteLine("File not found. No entries loaded.");
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
        }

    }

    //
    public void SaveFile()
    {
        // 
        Console.WriteLine("What is the filename?");
        _fileName = Console.ReadLine();

        // 
        try
        {
            using (StreamWriter writer = new StreamWriter(_fileName))
            {
                foreach (var entry in _entries)
                {
                    string entryString = $"{JsonSerializer.Serialize(entry._promptedResponses)},{entry._date}";
                    writer.WriteLine(entryString);
                }
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }
    }
}