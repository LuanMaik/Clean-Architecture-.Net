using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.InactivateCustomer;

public class InactivateCustomerCommandValidator : AbstractValidator<InactivateCustomerCommand>
{
    public InactivateCustomerCommandValidator()
    {
        RuleFor(x => x.IdCustomer).NotEmpty();
    }
}