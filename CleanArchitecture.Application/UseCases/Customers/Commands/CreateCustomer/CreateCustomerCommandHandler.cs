using CleanArchitecture.Application.Bus.Commands;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler: ICommandHandler<CreateCustomerCommand, CommandResult<Customer>>
{
    private readonly ICustomerRepository _customerRepository;
    
    private readonly CreateCustomerCommandValidator _validator;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, CreateCustomerCommandValidator validator)
    {
        _customerRepository = customerRepository;
        _validator = validator;
    }

    public async Task<CommandResult<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        if (_validator.IsValid(request) == false)
            return CommandResult<Customer>.Fail(_validator.GetErrorsMessages());
        
        var customer = new Customer(request.Name, request.Birthdate, request.Address, request.Phone);

        customer = await _customerRepository.CreateAsync(customer);
        
        return CommandResult<Customer>.Success(customer);
    }
    
}