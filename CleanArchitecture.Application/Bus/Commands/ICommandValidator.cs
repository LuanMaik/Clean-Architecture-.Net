﻿using CleanArchitecture.Application.Interfaces.CommandQuery;

namespace CleanArchitecture.Application.Bus.Commands;

public interface ICommandValidator<T>
{
    ICommandQueryValidator<T> Validator { get; }
}