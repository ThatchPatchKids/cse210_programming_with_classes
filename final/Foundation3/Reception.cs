

public class Reception : Event
{
    private List<string> _guests = new List<string>();

    public Reception(string title, string description, string date, string time, string street, string city, string state) : base(title, description, date, time, street, city, state)
    {
    }

    public void AddGuest(string guest)
    {
        // Guests need to RSVP.
        this._guests.Add(guest);
    }

    public override void DisplayFullDetails()
    {
        base.DisplayStandardDetails();
        Console.WriteLine("\nGuest List:");
        foreach (string guest in this._guests)
        {
            Console.WriteLine(guest);
        }
    }
}