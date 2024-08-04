using System;
using System.Collections.Generic;
using Maliroso_Task3_Databases;
using MongoDB.Bson;

class Program
{
    static void Main(string[] args)
    {
        // SQL Server operations
        var sqlContext = new ApplicationDbContext();
        var sqlRepository = new SqldbRepository(sqlContext);

        var product = new Product { ProductName = "Product 1", Price = 25000 };
        sqlRepository.AddProduct(product);

        List<Product> products = sqlRepository.GetAllProducts();
        Console.WriteLine("Products from SQL Server:");
        products.ForEach(p => Console.WriteLine($"{p.ProductID} - {p.ProductName} - {p.Price}"));

        // MongoDB operations
        var mongoContext = new MongoDbContext("mongodb://localhost:27017", "Maliroso_task3");
        var mongoRepository = new MongoDbRepository(mongoContext);

        var customer = new Customer { Name = "Igoni T George", Email = "kinggeorgetammy@gmail.com" };
        mongoRepository.AddCustomer(customer);

      

        List<Customer> customers = mongoRepository.GetAllCustomers();
        Console.WriteLine("Customers from MongoDB Database:");
        customers.ForEach(c => Console.WriteLine($"{c.CustomerId} - {c.Name} - {c.Email}"));
    }
}
