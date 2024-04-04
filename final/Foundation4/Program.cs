using System;
using System.Security.Cryptography;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        ExerciseTracker tracker = new ExerciseTracker();
        bool recording = true;
        while (recording)
        {
            tracker.ChooseActivity();
            Console.Write("Would you like to add another activity (y/n)? ");
            recording = Console.ReadLine() == "y";
        }
        tracker.DisplaySummaries();
    }
}