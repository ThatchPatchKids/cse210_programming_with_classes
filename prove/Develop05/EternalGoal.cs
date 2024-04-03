


public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[ ] {base.GetName()} ({base.GetDescription()})");
    }

    public override string ToString()
    {
        return $"EternalGoal~{base.GetName()}~{base.GetDescription()}~{base.GetPoints()}";
    }
}