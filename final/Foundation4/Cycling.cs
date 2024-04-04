using System.ComponentModel.DataAnnotations;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(int length, double speed) : base(length)
    {
        this._speed = speed;
    }

    public override double GetDistance()
    {
        return base.GetLength() / this.GetPace();
    }

    public override double GetSpeed()
    {
        return 60 / this.GetPace();
    }

    public override double GetPace()
    {
        return 60 / this._speed;
    }
}