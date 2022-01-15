using CleanArchitecture.Application.Bus.Interfaces;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
{
    private ICustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        // The command is validated in CleanArchitecture.Application.Bus.Behaviors.RequestValidationBehavior.cs
        // https://github.com/jbogard/MediatR/wiki/Behaviors

        var customer = await _customerRepository.GetByIdAsync(request.IdCustomer);

        if (customer == null)
        {
            throw new NotFoundException($"Not found Customer with Id {request.IdCustomer}");
        }

        return customer;
    }
}