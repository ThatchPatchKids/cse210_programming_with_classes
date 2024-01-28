using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;
        // job1.Display();

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2024;
        // job2.Display();

        Resume myResume = new Resume();
        // Individual Add calls:
        // myResume._jobs.Add(job1);
        // myResume._jobs.Add(job2);

        // One call to AddRange. This takes a collection as a parameter.
        myResume._jobs.AddRange(new[] { job1, job2 });
        myResume._name = "Some Person";
        Console.WriteLine();
        myResume.Display();
    }
}