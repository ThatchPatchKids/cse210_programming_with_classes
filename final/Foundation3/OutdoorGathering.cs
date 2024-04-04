

public class OutdoorGathering : Event
{
    private string _forecast;

    public OutdoorGathering(string title, string description, string date, string time, string street, string city, string state) : base(title, description, date, time, street, city, state)
    {
    }

    public void SetForecast(string forecast)
    {
        this._forecast = forecast;
    }

    public string GetForecast()
    {
        return this._forecast;
    }

    public override void DisplayFullDetails()
    {
        base.DisplayStandardDetails();
        Console.WriteLine($"Current Forecast: {this.GetForecast()}");
    }
}