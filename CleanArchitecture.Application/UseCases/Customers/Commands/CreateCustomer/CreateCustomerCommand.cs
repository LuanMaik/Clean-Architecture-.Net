using System.Text;
using CleanArchitecture.Application.Bus;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Interfaces.CommandQuery;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.CreateCustomer;

// Other approach it's you to define this class inside CreateCustomerCommandHandler.cs file, to get easier to discover where is the Command Handler

public record CreateCustomerCommand(string Name, DateTime Birthdate, Address Address, Phone Phone): ICommand<CommandResult<Customer?>>, ICommandValidator<CreateCustomerCommand>
{
    protected ICommandQueryValidator<CreateCustomerCommand> Validator;

    public bool IsValid()
    {
        Validator = GetValidator();
        return Validator.IsValid(this);
    }

    public IList<string> GetErrors()
    {
        return Validator.GetErrorsMessages();
    }


    public ICommandQueryValidator<CreateCustomerCommand> GetValidator()
    {
        return new CreateCustomerCommandValidator();
    }
}