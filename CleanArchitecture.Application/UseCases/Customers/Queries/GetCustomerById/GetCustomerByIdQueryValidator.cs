﻿using CleanArchitecture.Application.Bus;
using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQueryValidator : BaseCommandQueryValidator<GetCustomerByIdQuery>
{
    public GetCustomerByIdQueryValidator()
    {
        RuleFor(x => x.IdCustomer).NotEmpty();
    }
}