using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    private const int MaxExpectedLifeTime = 120;
    private const int MinAgeCustomer = 18;
        
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Name).MaximumLength(100).NotEmpty();
        
        RuleFor(x => x.Birthdate).NotEmpty();
        RuleFor(x => x.Birthdate.Year).LessThan(DateTime.Now.Year - MinAgeCustomer);
        RuleFor(x => x.Birthdate.Year).GreaterThan(DateTime.Now.Year - MaxExpectedLifeTime);
        
        RuleFor(x => x.Address.Street).MaximumLength(100).NotEmpty();
        RuleFor(x => x.Address.Neighborhood).MaximumLength(100).NotEmpty();
        RuleFor(x => x.Address.City).MaximumLength(100).NotEmpty();
        RuleFor(x => x.Address.ZipCode).MaximumLength(15).NotEmpty();
        
        RuleFor(x => x.Phone.CountryCode).MaximumLength(5).NotEmpty();
        RuleFor(x => x.Phone.RegionCode).MaximumLength(5).NotEmpty();
        RuleFor(x => x.Phone.Number).MaximumLength(15).NotEmpty();
    }
}