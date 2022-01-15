using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ValidationException = CleanArchitecture.Application.Exceptions.ValidationException;

namespace CleanArchitecture.Application.Bus.Behaviors;

public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var errorsMessages = new List<string>();
        
        var context = new ValidationContext<TRequest>(request);
        
        foreach (var validator in _validators)
        {
            List<ValidationFailure> errors = validator.Validate(context).Errors;
            
            foreach (ValidationFailure error in errors)
                errorsMessages.Add(error.ErrorMessage);
        }

        if (errorsMessages.Count != 0)
        {
            throw new ValidationException(errorsMessages);
        }

        return next();
    }
}