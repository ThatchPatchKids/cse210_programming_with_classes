

using System.Diagnostics.CodeAnalysis;

public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        this._radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Math.Pow(this._radius, 2);
    }
}