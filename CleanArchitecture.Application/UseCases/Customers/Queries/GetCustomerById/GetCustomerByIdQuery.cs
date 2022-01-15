using CleanArchitecture.Application.Bus.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.Customers.Queries.GetCustomerById;

public record GetCustomerByIdQuery(int IdCustomer): IRequest<Customer>;