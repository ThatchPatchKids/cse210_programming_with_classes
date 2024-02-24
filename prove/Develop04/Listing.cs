



public class Listing : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };


    public Listing(string name) : base(name)
    {
        base.SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n");
    }

    protected override void DisplayActivity()
    {
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        DisplayRandomPrompt();
        Console.Write("You may begin in: ");
        for (int i = 5; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(800);
                Console.Write("\b \b");
            }
        Console.WriteLine();
        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddSeconds(base.GetDuration());
        int itemCounter = 0;
        while (currentTime < futureTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            itemCounter += 1;
            currentTime = DateTime.Now;
        }
        Console.WriteLine($"You listed {itemCounter} items!");
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return this._prompts[random.Next(_prompts.Count)];
    }

    private void DisplayRandomPrompt()
    {
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
    }
}