using System;


public class Entry
{
    // Member variables/ Attributes:

    // Dictionary to store prompts and responses as key-value pairs.
    public Dictionary<string, string> _promptedResponses = new Dictionary<string, string>();

    // String to store the date of an entry/entries.
    public string _date;

    // Member functions/ Methods:

    // Construtor method.
    public Entry()
    {
        GetDate();
    }

    //
    public void SavePromptedResponse(string prompt, string response)
    {
        _promptedResponses.Add(prompt, response);
    }

    // Method for getting the current date.
    private void GetDate()
        {
            DateTime currentTime = DateTime.Now;
            _date = currentTime.ToShortDateString();
        }

    // Method for displaying an entry.
    public void DisplayEntry()
    {
        foreach (var item in _promptedResponses)
        {
            Console.WriteLine($"Date: {_date} - Prompt: {item.Key}");
            Console.WriteLine($"{item.Value}\n");
        }
    }
}