
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

public class Goal 
{
    private string _name;

    private string _description;

    private int _points;

    private bool _completed = false;
    public Goal(string name, string description, int points)
    {
        this._name = name;
        this._description = description;
        this._points = points;
    }

    public string GetName()
    {
        return this._name;
    }

    protected string GetDescription()
    {
        return this._description;
    }

    public virtual int GetPoints()
    {
        return this._points;
    }

    public virtual void SetCompleted()
    {
        this._completed = true;
    }

    public bool GetCompleted()
    {
        return this._completed;
    }

    public virtual void DisplayGoal()
    {
        if (this._completed)
        {
            Console.WriteLine($"[X] {this._name} ({this._description})");
        }
        else
        {
            Console.WriteLine($"[ ] {this._name} ({this._description})");
        }
    }
}