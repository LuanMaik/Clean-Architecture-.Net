using CleanArchitecture.Application.Bus;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Interfaces.Repositories;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.InactivateCustomer;

public class InactivateCustomerCommandHandler: ICommandHandler<InactivateCustomerCommand, CommandResult<bool>>
{
    private ICustomerRepository _customerRepository;

    public InactivateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async Task<CommandResult<bool>> Handle(InactivateCustomerCommand request, CancellationToken cancellationToken)
    {
        // The command is validated in CleanArchitecture.Application.Bus.Behaviors.RequestValidationBehavior.cs
        // https://github.com/jbogard/MediatR/wiki/Behaviors

        var validator = new InactivateCustomerCommandValidator();
        if(validator.Validate(request).IsValid == false) 
            return CommandResult<bool>.Fail(false, validator.GetErrorsMessages());

        var customer = await _customerRepository.GetByIdAsync(request.IdCustomer);
        
        if (customer == null)
        {
            throw new NotFoundException($"Not found Customer with Id {request.IdCustomer}");
        }
        
        customer.Inactivate();

        await _customerRepository.UpdateAsync(customer);

        return CommandResult<bool>.Success(true);
    }
}