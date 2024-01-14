using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int gradePerc = int.Parse(grade);
        string letterGrade;
        string sign;
        if (gradePerc >= 90) 
        {
            letterGrade = "A";
        }
        else if (gradePerc >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePerc >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePerc >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        if (gradePerc % 10 >= 7 && letterGrade != "A" && letterGrade != "F")
        {
            sign = "+";
        }
        else if (gradePerc %  10 <= 3 && letterGrade != "F")
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        Console.WriteLine($"You got a/an {letterGrade}{sign}");

        if (gradePerc >= 70)
        {
            Console.WriteLine("Congratulations! You've passed!");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass. Next time you'll do great!");
        }
    }
}