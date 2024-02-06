using System;

public class MenuOptions
{
    List<string> _menuOptions = new List<string>()
    {
        "1. Write",
        "2. Display",
        "3. Load",
        "4. Save",
        "5. Quit"
    };
    
    public MenuOptions()
    {
    }

    public void DisplayOptions()
    {
        foreach(string option in _menuOptions)
        {
            Console.WriteLine(option);
        }
    }
}