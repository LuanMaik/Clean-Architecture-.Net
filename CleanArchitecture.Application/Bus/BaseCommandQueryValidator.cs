using CleanArchitecture.Application.Interfaces.CommandQuery;
using FluentValidation;
using FluentValidation.Results;

namespace CleanArchitecture.Application.Bus;

public class BaseCommandQueryValidator<T>: AbstractValidator<T>, ICommandQueryValidator<T>
{
    
    private string[] _errorsMessages = Array.Empty<string>();
    
    public bool IsValid(T commandQuery)
    {
        ValidationResult result = Validate(commandQuery);

        if (result.IsValid)
            return true;

        _errorsMessages = result.Errors.Select(e => e.ErrorMessage).ToArray();
        
        return false;
    }

    public string[] GetErrorsMessages()
    {
        return _errorsMessages;
    }
}