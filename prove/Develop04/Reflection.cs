



public class Reflection : Activity
{

    HashSet<int> _usedIndices = new HashSet<int>();
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };


    public Reflection(string name) : base(name)
    {
        base.SetDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.\n");
    }

    protected override void DisplayActivity()
    {
        Console.WriteLine("Consider the following prompt:");
        DisplayRandomPrompt();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        for (int i = 5; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(800);
                Console.Write("\b \b");
            }
        Console.Clear();
        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddSeconds(base.GetDuration());

        while (currentTime < futureTime)
        {
            DisplayRandomQuestion();
            Console.WriteLine();
            currentTime = DateTime.Now;
        }
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return this._prompts[random.Next(_prompts.Count)];
    }

    private void DisplayRandomPrompt()
    {
        Console.WriteLine($"\n--- {GetRandomPrompt()}. ---\n");
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        int randomIndex = -1;
        bool valid = false;
        while (!valid)
        {
            randomIndex = random.Next(_questions.Count);
            bool containsIndex = _usedIndices.Contains(randomIndex);

            if (!containsIndex)
            {
                _usedIndices.Add(randomIndex);
                valid = true;
            }
            else if (_usedIndices.Count == _questions.Count)
            {
                return "Thats all the questions for this prompt.";
            }
        }

        return _questions[randomIndex];
    }

    private void DisplayRandomQuestion()
    {
        Console.Write($"> {GetRandomQuestion()} ");
        base.SpinAnimation(8);
    }
}