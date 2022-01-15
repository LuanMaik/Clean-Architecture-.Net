using CleanArchitecture.Application.Bus.Commands;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.InactivateCustomer;

public class InactivateCustomerCommandHandler: ICommandHandler<InactivateCustomerCommand, CommandResult<Customer>>
{
    private ICustomerRepository _customerRepository;
    
    private InactivateCustomerCommandValidator _validator;

    public InactivateCustomerCommandHandler(ICustomerRepository customerRepository, InactivateCustomerCommandValidator validator)
    {
        _customerRepository = customerRepository;
        _validator = validator;
    }

    public async Task<CommandResult<Customer>> Handle(InactivateCustomerCommand request, CancellationToken cancellationToken)
    {
        if(_validator.IsValid(request) == false) 
            return CommandResult<Customer>.Fail(_validator.GetErrorsMessages());

        var customer = await _customerRepository.GetByIdAsync(request.IdCustomer);
        
        if (customer == null)
            return CommandResult<Customer>.Fail($"Not found Customer with Id {request.IdCustomer}");
        
        customer.Inactivate();

        await _customerRepository.UpdateAsync(customer);

        return CommandResult<Customer>.Success(customer);
    }
}