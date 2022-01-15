using CleanArchitecture.Application.Bus;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQueryHandler : ICommandHandler<GetCustomerByIdQuery, CommandResult<Customer?>>
{
    private ICustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CommandResult<Customer?>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        // The command is validated in CleanArchitecture.Application.Bus.Behaviors.RequestValidationBehavior.cs
        // https://github.com/jbogard/MediatR/wiki/Behaviors

        var validator = new GetCustomerByIdQueryValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            return CommandResult<Customer?>.Fail(null, validator.GetErrorsMessages());
        }
        

        var customer = await _customerRepository.GetByIdAsync(request.IdCustomer);

        if (customer == null)
        {
            throw new NotFoundException($"Not found Customer with Id {request.IdCustomer}");
        }

        return CommandResult<Customer?>.Success(customer);
    }
}