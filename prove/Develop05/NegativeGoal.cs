

public class NegativeGoal : Goal
{
    private int _numFailed;

    public NegativeGoal(string name, string description, int points) : base(name, description, points)
    {

    }

    public override void SetCompleted()
    {
        this._numFailed++;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"{base.GetName()} ({base.GetDescription()}) -- Currently missed {this._numFailed} times.");
    }

    public override string ToString()
    {
        return $"NegativeGoal~{base.GetName()}~{base.GetDescription()}~{base.GetPoints()}~{this._numFailed}";
    }
}