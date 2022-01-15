using CleanArchitecture.Application.Bus.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.CreateCustomer;

// Other approach it's you to define this class inside CreateCustomerCommandHandler.cs file, to get easier to discover where is the Command Handler

public record CreateCustomerCommand(string Name, DateTime Birthdate, Address Address, Phone Phone):IRequest<Customer>
{
    protected string[] ErrorsMessages;
        
    public bool Validate()
    {
        var validator = new CreateCustomerCommandValidator();
        var result = validator.Validate(this);
        
        if (result.IsValid == false)
        {
            ErrorsMessages = result.Errors.Select(e => e.ErrorMessage).ToArray();
        }

        return result.IsValid;
    }

    public string[] GetErrorsMessages()
    {
        return ErrorsMessages;
    }
}