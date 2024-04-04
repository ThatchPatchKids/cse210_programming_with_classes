

using System.Security;

public class Order 
{
    private List<Product> _products = new List<Product>();

    private Customer _customer;

    public Order(string name, string streetAddress, string city, string state, string country)
    {
        // this.SetCustomer(name);

        // I think it's more encapsulated without a setter method.
        this._customer = new Customer(name, streetAddress, city, state, country);
    }

    // public void SetCustomer(string name)
    // {
    //     this._customer = new Customer(name);
    // }

    public void AddProduct(string name, string productID, double price, int quantity)
    {
        this._products.Add(new Product(name, productID, price, quantity));
    }

    public double GetCost()
    {
        double cost = 0;
        foreach (Product product in this._products)
        {
            cost += product.GetTotalCost();
        }
        return cost;
    }

    public string GetPackingLabel(int i_product)
    {
        return $"{this._products[i_product].GetProductName()} - {this._products[i_product].GetProductID()}";
    }

    public string GetShippingLabel()
    {
        return $"{this._customer.GetName()} {this._customer.GetAddress()}";
    }

    public int GetShippingCost()
    {
        if (this._customer.IsResident())
        {
            return 5;
        }
        else
        {
            return 35;
        }
    }

    public double GetTotalPrice()
    {
        return this.GetCost() + this.GetShippingCost();
    }

    public void DisplayOrders()
    {
        Console.WriteLine();
        for (int i=0; i < this._products.Count; i++)
        {
            Console.WriteLine(this.GetPackingLabel(i));
        }
        Console.WriteLine(this.GetShippingLabel());
        Console.WriteLine($"${this.GetTotalPrice()}");
    }
}