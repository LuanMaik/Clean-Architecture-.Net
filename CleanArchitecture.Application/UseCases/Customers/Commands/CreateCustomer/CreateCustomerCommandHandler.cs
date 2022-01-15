using CleanArchitecture.Application.Bus.Interfaces;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler: IRequestHandler<CreateCustomerCommand, Customer>
{
    private ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        // The command is validated in CleanArchitecture.Application.Bus.Behaviors.RequestValidationBehavior.cs
        // https://github.com/jbogard/MediatR/wiki/Behaviors
        
        var customer = new Customer(request.Name, request.Birthdate, request.Address, request.Phone);

        customer = await _customerRepository.CreateAsync(customer);
        
        return customer;
    }
    
}