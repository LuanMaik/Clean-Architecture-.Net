using CleanArchitecture.Application.Bus;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler: ICommandHandler<CreateCustomerCommand, CommandResult>
{
    private ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CommandResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        // The command is validated in CleanArchitecture.Application.Bus.Behaviors.RequestValidationBehavior.cs
        // https://github.com/jbogard/MediatR/wiki/Behaviors

        var validator = new CreateCustomerCommandValidator();
        if (validator.IsValid(request) == false)
        {
            return CommandResult.Fail(validator.GetErrorsMessages());
        }
        
        var customer = new Customer(request.Name, request.Birthdate, request.Address, request.Phone);

        customer = await _customerRepository.CreateAsync(customer);
        
        return CommandResult.Success(customer);
    }
    
}