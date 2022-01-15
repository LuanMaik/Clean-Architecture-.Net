using CleanArchitecture.Application.Bus;
using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.InactivateCustomer;

public class InactivateCustomerCommandValidator : BaseCommandQueryValidator<InactivateCustomerCommand>
{
    public InactivateCustomerCommandValidator()
    {
        RuleFor(x => x.IdCustomer).NotEmpty();
    }
}