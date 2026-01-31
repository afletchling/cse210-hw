using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Order order1 = new(
            new Customer("John Meef", new Address(
                "651 Toot Street",
                "Albany",
                "New York",
                "USA"
            ))
        );

        order1.AddProduct(new Product("Grapes", "B84JTGV4B", 1.49, 5));
        order1.AddProduct(new Product("Jelly", "GJR95YY5T", 5.21, 1));

        Console.WriteLine("Order 1\nCart:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\nShipping:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.GetTotal()}");
        Console.WriteLine("");

        Order order2 = new(
            new Customer("Ben Ten", new Address(
                "81 Route 44",
                "Kenora",
                "Ontario",
                "Canada"
            ))
        );

        order2.AddProduct(new Product("Can of Beans", "MHKO4IF8V", 3.67, 3));
        order2.AddProduct(new Product("Bread Loaf", "OF9EFJJTG", 6.84, 2));
        order2.AddProduct(new Product("Cookies", "GJR0GKTTH", 7.42, 1));

        Console.WriteLine("Order 2\nCart:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\nShipping:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.GetTotal()}");
    }
}