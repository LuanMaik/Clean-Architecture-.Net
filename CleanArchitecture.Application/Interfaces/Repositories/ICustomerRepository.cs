using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Repositories;

public interface ICustomerRepository
{
    public Task<IEnumerable<Customer>> ListAsync();
    public Task<Customer?> GetByIdAsync(int id);
    public Task<Customer> CreateAsync(Customer customer);
    public Task<Customer> UpdateAsync(Customer customer);
}