using System.Security;

public abstract class Activity 
{
    private DateTime _date;

    private int _length;

    public Activity(int length)
    {
        this._length = length;
        this._date = DateTime.Now;
    }

    public int GetLength()
    {
        return this._length;
    }

    public string GetDate()
    {
        return this._date.ToString("dd MMM yyyy");
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{this.GetDate()} {this.ToString()} ({this._length} min): Distance {this.GetDistance()} km, Speed {this.GetSpeed()} kph, Pace: {this.GetPace()} min per km";
    }
}