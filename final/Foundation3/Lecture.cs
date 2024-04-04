

public class Lecture : Event
{
    private string _speaker;

    private int _capacity = 80;

    public Lecture(string title, string description, string date, string time, string street, string city, string state) : base(title, description, date, time, street, city, state)
    {

    }

    public void SetSpeaker(string speaker)
    {
        this._speaker = speaker;
    }

    public override void DisplayFullDetails()
    {
        base.DisplayStandardDetails();
        Console.WriteLine($"Speaking: {this._speaker}");
        Console.WriteLine($"Capacity: {this._capacity}");
    }
}