using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;


    public class CustomerService(ICustomerRepository customerRepository)
{
    private readonly ICustomerRepository _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));

    // Skapa en ny kund
    public async Task CreateCustomerAsync(CustomerRegistrationForm form)
    {
        var existingCustomer = await _customerRepository.GetAsync(c => c.CustomerName == form.CustomerName);
        if (existingCustomer != null)
        {
            Console.WriteLine("Customer name already exists.");
            return;
        }

        var customerEntity = CustomerFactory.Create(form);
        await _customerRepository.CreateAsync(customerEntity!);
        Console.WriteLine("Customer created successfully.");
    }

    // Hämta alla kunder
    public async Task<IEnumerable<CustomerModel>> GetCustomersAsync()
    {
        var customerEntities = await _customerRepository.GetAsync();
        return customerEntities
            .Select(CustomerFactory.Create)
            .Where(customer => customer != null)!;
    }

    // Hämta kund baserat på ID
    public async Task<CustomerModel?> GetCustomerByIdAsync(int id)
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.Id == id);

        if (customerEntity == null)
        {
            Console.WriteLine($"Ingen kund hittades med ID: {id}");
            return null;
        }

        return CustomerFactory.Create(customerEntity);
    }

    // Hämta kund baserat på kundnamn
    public async Task<CustomerModel?> GetCustomerByCustomerNameAsync(string customerName)
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.CustomerName == customerName);
        return CustomerFactory.Create(customerEntity!);
    }

    // Uppdatera kundinformation
    public async Task<bool> UpdateCustomerAsync(CustomerModel customer)
    {
        var existingCustomer = await _customerRepository.GetAsync(x => x.Id == customer.Id);
        if (existingCustomer == null)
            return false;

        existingCustomer.CustomerName = customer.CustomerName;
        await _customerRepository.UpdateAsync(x => x.Id == customer.Id, existingCustomer);
        return true;
    }

    // Ta bort en kund
    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var existingCustomer = await _customerRepository.GetAsync(x => x.Id == id);
        if (existingCustomer == null)
            return false;

        await _customerRepository.DeleteAsync(x => x.Id == existingCustomer.Id);
        return true;
    }
}


