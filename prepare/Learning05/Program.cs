using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("yellow", 5);
        Circle circle = new Circle("red", 4);
        Rectangle rectangle = new Rectangle("blue", 5, 2);

        List<Shape> shapes = new List<Shape>()
        {
            square,
            circle,
            rectangle
        };

        foreach(Shape shape in shapes)
        {
            Console.WriteLine($"The shapes color is: {shape.GetColor()} and its area is: {shape.GetArea()}");
        }
    }
}