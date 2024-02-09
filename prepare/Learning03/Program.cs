using System;

class Program
{
    static void Main(string[] args)
    {   
        // 
        Fraction fraction = new Fraction();
        // 
        Console.WriteLine(fraction.GetFractionString());
        // 
        Console.WriteLine(fraction.GetDecimalValue());

        //
        Fraction myFraction = new Fraction(5);
        // 
        Console.WriteLine(myFraction.GetFractionString());
        //
        Console.WriteLine(myFraction.GetDecimalValue());

        //
        Fraction yourFraction = new Fraction(3, 4);
        //
        Console.WriteLine(yourFraction.GetFractionString());
        //
        Console.WriteLine(yourFraction.GetDecimalValue());

        Fraction theirFraction = new Fraction(1, 3);
        //
        Console.WriteLine(theirFraction.GetFractionString());
        //
        Console.WriteLine(theirFraction.GetDecimalValue());

    }
}