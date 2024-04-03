


using System.Drawing;

public class ChecklistGoal : Goal
{
    private int _numTimes;

    private int _numCompleted = 0;

    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int times, int bonus) : base(name, description, points)
    {
        this._numTimes = times;
        this._bonus = bonus;
    }

    public override string ToString()
    {
        return $"ChecklistGoal~{base.GetName()}~{base.GetDescription()}~{base.GetPoints()}~{this._bonus}~{this._numTimes}~{this._numCompleted}";
    }

    public override void SetCompleted()
    {
        this._numCompleted ++;
    }

    public override int GetPoints()
    {
        if (this._numCompleted == this._numTimes)
        {
            return base.GetPoints() + this._bonus;
        }
        else
        {
            return base.GetPoints();
        }
    }

    public override void DisplayGoal()
    {
        if (this._numCompleted == this._numTimes)
        {
            Console.WriteLine($"[X] {base.GetName()} ({base.GetDescription()}) -- Currently completed: {this._numCompleted}/{this._numTimes}");
        }
        else
        {
            Console.WriteLine($"[ ] {base.GetName()} ({base.GetDescription()}) -- Currently completed: {this._numCompleted}/{this._numTimes}");
        }
    }
}