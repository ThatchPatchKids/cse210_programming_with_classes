

public class Product 
{
    private string _name;

    private string _productID;

    private double _price;

    private int _quantity;

    public Product(string name, string productID, double price, int quantity)
    {
        this._name = name;
        this._productID = productID;
        this._price = price;
        this._quantity = quantity;
    }

    public double GetTotalCost()
    {
        return this._price * this._quantity;
    }

    public string GetProductName()
    {
        return this._name;
    }

    public string GetProductID()
    {
        return this._productID;
    }
}