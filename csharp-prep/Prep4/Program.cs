using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        int number;
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do {
            Console.Write("Enter a number: ");
            string numString = Console.ReadLine();
            number = int.Parse(numString);
            numbers.Add(number);

        } while (number != 0);

        int sum = numbers.Sum();
        int avg = sum / numbers.Count;
        int largestNum = numbers.Max();
        var positiveNumbers = numbers.Where(num => num > 0);
        int smallestPositive = positiveNumbers.Min();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {largestNum}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        // numbers.ForEach(number => Console.WriteLine(number));
        numbers.Sort(); numbers.ForEach(Console.WriteLine);
    }
}