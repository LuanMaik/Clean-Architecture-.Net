using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdQuery>
{
    public GetCustomerByIdQueryValidator()
    {
        RuleFor(x => x.IdCustomer).NotEmpty();
    }
}