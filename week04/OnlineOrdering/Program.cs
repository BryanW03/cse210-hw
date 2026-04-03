using System;

class Program
{
    static void Main(string[] args)
    {
        
        Address address1 = new Address("123 Tech Boulevard", "San Francisco", "CA", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);
        
        order1.AddProduct(new Product("Wireless Mouse", "WM-01", 25.50, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "MK-99", 120.00, 1));

       
        Address address2 = new Address("456 Maple Street", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Smith", address2);
        Order order2 = new Order(customer2);
        
        order2.AddProduct(new Product("Ultra-wide Monitor", "MN-34", 350.00, 1));
        order2.AddProduct(new Product("HDMI Cable", "CB-05", 15.00, 3));
        order2.AddProduct(new Product("Desk Mat", "DM-02", 20.00, 1));

        
        Console.WriteLine(new string('=', 40));
        Console.WriteLine("ORDER 1 DETAILS");
        Console.WriteLine(new string('=', 40));
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotal():0.00}\n");

        Console.WriteLine(new string('=', 40));
        Console.WriteLine("ORDER 2 DETAILS");
        Console.WriteLine(new string('=', 40));
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotal():0.00}\n");
    }
}