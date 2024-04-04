using System.ComponentModel.Design;
using System.Runtime.InteropServices;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(int length, int laps) : base(length)
    {
        this._laps = laps;
    }

    public override double GetDistance()
    {
        // Console.WriteLine($"Laps: {this._laps} Distance: {this._laps * 50 / 1000}");
        return this._laps * 50.0 / 1000.0;
    }

    public override double GetSpeed()
    {
        // Console.WriteLine($"Distance: {this.GetDistance()} Minutes: {base.GetLength()} Distance / Minutes: {this.GetDistance() / base.GetLength()} Distance / Minutes x 60: {(this.GetDistance() / base.GetLength()) * 60}");
        return (this.GetDistance() / base.GetLength()) * 60;
    }

    public override double GetPace()
    {
        // Console.WriteLine($"Minutes: {base.GetLength()} Distance: {this.GetDistance()} Minutes / Distance: {base.GetLength() / this.GetDistance()}");
        return base.GetLength() / this.GetDistance();
    }
}