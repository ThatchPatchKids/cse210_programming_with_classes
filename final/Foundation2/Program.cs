using System;

class Program
{
    static void Main(string[] args)
    {
        Order order1 = new Order("Trump", "725 5th Ave", "NYC", "NY", "United States");
        Order order2 = new Order("Vladimir", "The Kremlin", "Moscow", "Moscow", "Russia");

        
        order1.AddProduct("Rogaine", "4321", 10, 6);
        order1.AddProduct("Wig", "54321", 30, 2);


        order2.AddProduct("Suit-Black", "2012", 5000, 1);
        order2.AddProduct("Tie-Black", "1952", 350, 1);
        order2.AddProduct("American Intelligence", "WeDontSellYourData", 100000, 10000);

        order1.DisplayOrders();
        order2.DisplayOrders();

    }
}