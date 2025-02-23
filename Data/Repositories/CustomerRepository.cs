using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Data.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
{

}

//public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository

//{
//    private readonly DataContext _context = context;

//// Skapa en ny kund (Create)
//public override async Task<CustomerEntity> CreateAsync(CustomerEntity customerEntity)
//{
//    ArgumentNullException.ThrowIfNull(customerEntity);


//    await _context.Customers.AddAsync(customerEntity);
//    await _context.SaveChangesAsync();
//    return customerEntity;
//}

//// Hämta kund baserat på ett uttryck (Read)
//public override async Task<CustomerEntity?> GetAsync(Expression<Func<CustomerEntity, bool>> expression)
//{
//    return await _context.Customers.FirstOrDefaultAsync(expression);
//}

//// Hämta alla kunder (Read)
//public override async Task<IEnumerable<CustomerEntity>> GetAsync()
//{
//    return await _context.Customers.ToListAsync();
//}



// Uppdatera en befintlig kund (Update)
//public override async Task<CustomerEntity?> UpdateAsync(Expression<Func<CustomerEntity, bool>> expression, CustomerEntity updatedEntity)
//{
//    if (updatedEntity == null)
//        throw new ArgumentNullException(nameof(updatedEntity));

//    var existingCustomer = await _context.Customers.FirstOrDefaultAsync(expression);
//    if (existingCustomer == null)
//        return null;

//    _context.Entry(existingCustomer).CurrentValues.SetValues(updatedEntity);
//    await _context.SaveChangesAsync();
//    return existingCustomer;
//}

// Radera en kund (Delete)
//    public override async Task<bool> DeleteAsync(Expression<Func<CustomerEntity, bool>> expression)
//    {
//        var existingCustomer = await _context.Customers.FirstOrDefaultAsync(expression);
//        if (existingCustomer == null)
//            return false;

//        _context.Customers.Remove(existingCustomer);
//        await _context.SaveChangesAsync();
//        return true;
//    }


//}


