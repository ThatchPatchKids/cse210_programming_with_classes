

public class Address 
{
    private string _street;

    private string _city;

    private string _state;

    public Address(string street, string city, string state)
    {
        this._street = street;
        this._city = city;
        this._state = state;
    }

    public string GetAddress()
    {
        // How should this be formatted?
        return $"{this._street}, {this._city}, {this._state}";
    }
}