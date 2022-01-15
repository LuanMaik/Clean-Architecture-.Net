using CleanArchitecture.Application.Bus.Interfaces;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Interfaces.Repositories;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.InactivateCustomer;

public class InactivateCustomerCommandHandler: IRequestHandler<InactivateCustomerCommand, bool>
{
    private ICustomerRepository _customerRepository;

    public InactivateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async Task<bool> Handle(InactivateCustomerCommand request, CancellationToken cancellationToken)
    {
        // The command is validated in CleanArchitecture.Application.Bus.Behaviors.RequestValidationBehavior.cs
        // https://github.com/jbogard/MediatR/wiki/Behaviors

        var customer = await _customerRepository.GetByIdAsync(request.IdCustomer);
        
        if (customer == null)
        {
            throw new NotFoundException($"Not found Customer with Id {request.IdCustomer}");
        }
        
        customer.Inactivate();

        await _customerRepository.UpdateAsync(customer);

        return true;
    }
}