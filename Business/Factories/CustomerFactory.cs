using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    // Skapar en CustomerEntity från CustomerRegistrationForm
    public static CustomerEntity? Create(CustomerRegistrationForm form) =>
        form == null ? null : new CustomerEntity
        {
            CustomerName = form.CustomerName,
        };

    // Skapar en CustomerModel från CustomerEntity
    public static CustomerModel? Create(CustomerEntity? entity) =>
        entity == null ? null : new CustomerModel
        {
            Id = entity.Id,
            CustomerName = entity.CustomerName,
        };
}

