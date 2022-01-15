using CleanArchitecture.Application.Interfaces.CommandQuery;

namespace CleanArchitecture.Application.Common;

public interface ICommandValidator<T>
{
    ICommandQueryValidator<T> GetValidator();
}