using CleanArchitecture.Application.Bus;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.Customers.Queries.GetCustomerById;

public record GetCustomerByIdQuery(int IdCustomer): ICommand<CommandResult<Customer?>>;