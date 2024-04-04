

public class Event
{
    private string _title;

    private string _description;

    private string _date;

    private string _time;

    private Address _address;

    public Event(string title, string description, string date, string time, string street, string city, string state)
    {
        this._title = title;
        this._description = description;
        this._date = date;
        this._time = time;
        this._address = new Address(street, city, state);
    }

    public void DisplayStandardDetails()
    {
        Console.WriteLine($"Event: {this._title}");
        Console.WriteLine($"When: {this._date} at {this._time}");
        Console.WriteLine($"Description: {this._description}");
        Console.WriteLine($"Address: {this._address.GetAddress()}");
    }

    public virtual void DisplayFullDetails()
    {
        this.DisplayStandardDetails();
    }

    public void DisplayShortDescription()
    {
        Console.Write($"Type: {this.ToString()}, Title: {this._title}, Date: {this._date}");
    }
}