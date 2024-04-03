


public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override string ToString()
    {
        return $"SimpleGoal~{base.GetName()}~{base.GetDescription()}~{base.GetPoints()}~{base.GetCompleted()}";
    }
}
