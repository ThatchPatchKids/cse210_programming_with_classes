using System.Reflection;

public class ExerciseTracker
{
    private List<Activity> _activities = new List<Activity>();

    public ExerciseTracker()
    {

    }

    public void AddActivity(int activity)
    {
        Console.Write("How long did you exercise for (in minutes)? ");
        int minutes = int.Parse(Console.ReadLine());

        switch (activity)
        {
            case 1: 
                Console.Write("How far did you run (in km)? ");
                double km = double.Parse(Console.ReadLine());
                this._activities.Add(new Running(minutes, km));
                break;
            case 2:
                Console.Write("How fast did you peddle (in km/hr)? ");
                double speed = double.Parse(Console.ReadLine());
                this._activities.Add(new Cycling(minutes, speed));
                break;
            case 3:
                Console.Write("How many laps did you swim? ");
                int laps = int.Parse(Console.ReadLine());
                this._activities.Add(new Swimming(minutes, laps));
                break;
            default:
                break;
        }
    }

    public void DisplaySummaries()
    {
        Console.WriteLine();
        foreach (Activity activity in this._activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }

    public void ChooseActivity()
    {
        Console.WriteLine("\nWhich activity did you complete?");
        Console.WriteLine("   1. Running");
        Console.WriteLine("   2. Cycling");
        Console.WriteLine("   3. Swimming");
        Console.Write("   > ");
        int activity = int.Parse(Console.ReadLine());
        this.AddActivity(activity);
    }
}