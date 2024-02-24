
public class Breathing : Activity
{
    public Breathing(string name) : base(name)
    {
        base.SetDescription("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.\n");
    }

    protected override void DisplayActivity()
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(base.GetDuration());
        while (DateTime.Now < futureTime)
        {
            Console.WriteLine("\n");
            Console.Write("Breathe in...");
            for (int i = 5; i > 0; i--)   // I reuse this code a lot, could I write a function that does it for me?
            {
                Console.Write(i);
                Thread.Sleep(800);
                Console.Write("\b \b");
            }
            Console.WriteLine();
            Console.Write("Now breathe out...");
            for (int i = 6; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(800);
                Console.Write("\b \b");
            }
        }
        Console.WriteLine();
    }
}