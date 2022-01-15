using CleanArchitecture.Application.Bus;
using CleanArchitecture.Application.Common;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.InactivateCustomer;

public record InactivateCustomerCommand (int IdCustomer) : ICommand<CommandResult<bool>>;