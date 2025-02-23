using System;
using System.Collections.Generic;
using Business.Models;
using Business.Services;
namespace Presentation_ConsoleApp.Dialogs;

public class CustomerDialog
{
    private readonly CustomerService _customerService;

    public CustomerDialog(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task CreateNewCustomer()
    {
        Console.Write("Enter Customer Name: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Customer name cannot be empty.");
            Console.ReadKey();
            return;
        }

        await _customerService.CreateCustomerAsync(new CustomerRegistrationForm { CustomerName = name });
        Console.WriteLine("Customer created successfully.");
        Console.ReadKey();
    }

    public async Task GetAllCustomers()
    {
        var customers = await _customerService.GetCustomersAsync();

        Console.WriteLine("All Customers:");
        foreach (var customer in customers)
        {
            Console.WriteLine($"ID: {customer.Id}, Name: {customer.CustomerName}");
        }

        if (!customers.Any())
        {
            Console.WriteLine("No customers found.");
        }

        Console.ReadKey();
    }
}
