using CleanArchitecture.Application.Bus.Commands;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.InactivateCustomer;

public record InactivateCustomerCommand (int IdCustomer) : ICommand<CommandResult<Customer>>;