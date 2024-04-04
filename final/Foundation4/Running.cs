

public class Running : Activity
{
    private double _distance;

    public Running(int length, double distance) : base(length)
    {
        this._distance = distance;
    }

    public override double GetDistance()
    {
        return this._distance;
    }

    public override double GetSpeed()
    {
        return (this._distance / base.GetLength()) * 60;
    }

    public override double GetPace()
    {
        return base.GetLength() / this._distance;
    }
}