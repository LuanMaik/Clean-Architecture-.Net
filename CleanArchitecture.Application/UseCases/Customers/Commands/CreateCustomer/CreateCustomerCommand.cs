using CleanArchitecture.Application.Bus.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.CreateCustomer;

// Other approach it's you to define this class inside CreateCustomerCommandHandler.cs file, to get easier to discover where is the Command Handler

public record CreateCustomerCommand(string Name, DateTime Birthdate, Address Address, Phone Phone): ICommand<CommandResult<Customer>>;