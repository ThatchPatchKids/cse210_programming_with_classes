

using System.Runtime.CompilerServices;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private string _welcomeMessage;
    private string _endMessage = "Well done!!";
    private string _summaryMessage;

    
    public Activity(string name)
    {   
        this._name = name;
        this._welcomeMessage = $"Welcome to the {this._name} Activity.\n";
        // SetWelcomeMessage();   // Is this okay to do? I could also call this method in the DisplayWelcomeMessage().
    }

    private void SetWelcomeMessage()
    {
        this._welcomeMessage = $"Welcome to the {this._name} Activity.\n";
    }

    private void DisplayWelcomeMessage()
    {
        // Clear the console first.
        Console.Clear();
        Console.WriteLine(_welcomeMessage);
    }

    protected void SetDescription(string description)
    {
        this._description = description;
    }

    private void DisplayDescription()
    {
        Console.WriteLine(_description);
    }

    private void SetDuration()
    // private void SetDuration(int duration)
    {
        // this._duration = duration;   // Is this better than the code  below?
        Console.Write("How long, in seconds, would you like for your session? ");
        this._duration = int.Parse(Console.ReadLine());
    }

    protected int GetDuration()
    {
        return this._duration;
    }

    protected void SpinAnimation(int spinDuration)
    {
        List<string> spins = new List<string>()
        {
            "-",
            "\\",
            "|",
            "/"
        };
        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddSeconds(spinDuration);
        while (currentTime < futureTime)
        {
            foreach (string spin in spins)
            {
                Console.Write(spin);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
            currentTime = DateTime.Now;
        }
    }

    private void SetSummaryMessage()
    {
        this._summaryMessage = $"\nYou have completed another {this._duration} seconds of the {this._name} Activity.";
    }

    private void StartActivity()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        SpinAnimation(4);
    }

    protected virtual void DisplayActivity()
    {
        Console.WriteLine("This is an activiy");
    }

    private void DisplayEndMessage()
    {
        Console.WriteLine();
        Console.WriteLine(_endMessage);
        SpinAnimation(4);
    }

    private void DisplaySummary()
    {
        Console.WriteLine(_summaryMessage);
        SpinAnimation(4);
    }

    public void RunActivity()
    {
        DisplayWelcomeMessage();
        DisplayDescription();
        SetDuration();
        SetSummaryMessage();
        StartActivity();
        DisplayActivity();
        DisplayEndMessage();
        DisplaySummary();
    }
}