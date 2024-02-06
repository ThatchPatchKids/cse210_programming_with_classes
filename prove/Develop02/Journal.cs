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

        // 

    }

    //
    public void SaveFile()
    {
        // 
        Console.WriteLine("What is the filename?");
        _fileName = Console.ReadLine();

        // 
        
    }
}