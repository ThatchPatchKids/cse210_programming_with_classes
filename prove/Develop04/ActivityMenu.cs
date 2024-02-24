


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

public class ActivityMenu
{
    private List<string> _menuOptions = new List<string>()
    {
        "   1. Start breathing activity",
        "   2. Start reflecting activity",
        "   3. Start listing activity",
        "   4. Quit"
    };
    private int _choice;

    private Reflection _reflection = new Reflection("Reflecting");  // _reflectionActivity
    private Breathing _breathing = new Breathing("Breathing");   // _breathingActivity
    private Listing _listing = new Listing("Listing");   // _listingActivity
    
    public ActivityMenu()
    {
    }

    private void DisplayOptions()
    {
        // Clear the console first.
        Console.Clear();
        Console.WriteLine("Menu Options:");

        foreach(string option in _menuOptions)
        {
            Console.WriteLine(option);
        }
    }

    private void ChooseActivity()   // Not in love with this func. name.
    {   
        bool valid = false;
        while (!valid)
        {
            try
            {
                Console.Write("Select a choice from the menu: ");
                this._choice = int.Parse(Console.ReadLine());
                valid = true;
            }
            catch 
            {
                Console.WriteLine("Sorry, invalid option.");
            }
        }
    }

    private bool DoActivity()   // I don't like this function name.
    {
        bool running = true;
        switch (_choice)
        {
            case 1:
                _breathing.RunActivity();
                break;
            case 2:
                _reflection.RunActivity();
                break;
            case 3:
                _listing.RunActivity();
                break;
            case 4:
                running = false;
                break;
            default:
                Console.WriteLine("Sorry, that is not an option.");
                break;
        }
        return running;
    }

    public void RunMenu()
    {
        bool running = true;
        while (running)
        {
            DisplayOptions();
            ChooseActivity();
            running = DoActivity();
        }
    }
}