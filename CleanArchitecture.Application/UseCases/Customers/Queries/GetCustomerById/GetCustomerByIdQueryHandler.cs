using CleanArchitecture.Application.Bus.Commands;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQueryHandler : ICommandHandler<GetCustomerByIdQuery, CommandResult<Customer>>
{
    private ICustomerRepository _customerRepository;
    private GetCustomerByIdQueryValidator _validator;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, GetCustomerByIdQueryValidator validator)
    {
        _customerRepository = customerRepository;
        _validator = validator;
    }

    public async Task<CommandResult<Customer>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        if (_validator.IsValid(request) == false)
            return CommandResult<Customer>.Fail(_validator.GetErrorsMessages());

        var customer = await _customerRepository.GetByIdAsync(request.IdCustomer);

        if (customer == null)
            return CommandResult<Customer>.Fail($"Not found Customer with Id {request.IdCustomer}");

        return CommandResult<Customer>.Success(customer);
    }
}