using System;

class Program
{
    static void Main(string[] args)
    {
        Lecture lecture = new Lecture("Fireside", "Brother so-and-so will speak to the youth.", "4/3/24", "7:00pm", "Main Ave", "Rexburg", "ID");
        lecture.SetSpeaker("Brother so-and-so");

        Reception reception = new Reception("John and Jane Doe", "Join John and Jane at their wedding reception", "4/3/24", "2:00pm", "Second Ave", "Rexburg", "ID");
        reception.AddGuest("Smith Family");
        reception.AddGuest("Brown Family");
        reception.AddGuest("Miller Family");
        reception.AddGuest("Jones Family");
        reception.AddGuest("Johnson Family");
        reception.AddGuest("Garcia Family");
        reception.AddGuest("Queen of England");
        reception.AddGuest("Mr. and Mrs. Claus");

        OutdoorGathering outdoorGathering = new OutdoorGathering("Summer BBQ", "Join us for a summer BBQ", "4/3/24", "6:00pm", "Third Ave", "Rexburg", "ID");
        outdoorGathering.SetForecast("Partly Cloudy");

        Console.WriteLine();
        lecture.DisplayStandardDetails();
        Console.WriteLine();
        lecture.DisplayFullDetails();
        Console.WriteLine();
        lecture.DisplayShortDescription();
        Console.WriteLine();

        Console.WriteLine();
        reception.DisplayStandardDetails();
        Console.WriteLine();
        reception.DisplayFullDetails();
        Console.WriteLine();
        reception.DisplayShortDescription();
        Console.WriteLine();

        Console.WriteLine();
        outdoorGathering.DisplayStandardDetails();
        Console.WriteLine();
        outdoorGathering.DisplayFullDetails();
        Console.WriteLine();
        outdoorGathering.DisplayShortDescription();
        Console.WriteLine();
    }
}