

public class Customer 
{
    private string _name;

    private Address _address;

    public Customer(string name, string streetAddress, string city, string state, string country)
    {
        this._name = name;
        // Option 1, is this more or less Encapsulated this way?
        // this.SetAddress(streetAddress, city, state, country);
        
        // Option 2, is this more or less Encapsulated this way?
        this._address = new Address(streetAddress, city, state, country);
    }

    // public void SetAddress(string streetAddress, string city, string state, string country)
    // {
    //     this._address = new Address(streetAddress, city, state, country);
    // }

    public bool IsResident()
    {
        return this._address.IsFromUSA();
    }

    public string GetName()
    {
        return this._name;
    }

    public string GetAddress()
    {
        return this._address.GetAddress();
    }
}