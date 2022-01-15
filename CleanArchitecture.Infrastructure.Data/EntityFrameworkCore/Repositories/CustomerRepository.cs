using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Infrastructure.Data.EntityFrameworkCore.Repositories;

public class CustomerRepository: ICustomerRepository
{
    public Task<IEnumerable<Customer>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        if (id == 10)
            return null;
        
        var customer = new Customer("Test", DateTime.Now.AddYears(-18), 
            new Address("Street x", "Center", "Test", "123456"),
            new Phone("+55", "44", "999999999"));

        return await Task.FromResult(customer);
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        return await Task.FromResult(customer);
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        return await Task.FromResult(customer);
    }
}