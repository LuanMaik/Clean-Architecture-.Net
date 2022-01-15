using CleanArchitecture.Application.Bus.Interfaces;

namespace CleanArchitecture.Application.UseCases.Customers.Commands.InactivateCustomer;

public record InactivateCustomerCommand(int IdCustomer) : IRequest<bool>;