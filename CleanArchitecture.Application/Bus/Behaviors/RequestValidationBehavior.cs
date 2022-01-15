using CleanArchitecture.Application.Interfaces.CommandQuery;
using FluentValidation;
using MediatR;
using ValidationException = CleanArchitecture.Application.Exceptions.ValidationException;

namespace CleanArchitecture.Application.Bus.Behaviors;

public class RequestValidationBehavior<TRequest, TResponse> : MediatR.IPipelineBehavior<TRequest, TResponse> where TRequest : Interfaces.IRequest<TResponse> where TResponse : CommandResult
{
    private readonly ICommandQueryValidator<TRequest> _validator;

    public RequestValidationBehavior(IValidator<TRequest> validator)
    {
        // Check if validator was found
        if (validator is null)
        {
            throw new NotImplementedException($"{typeof(TRequest)} there is no validator implemented. Create it!");
        }

        // Check if validator implements ICommandQueryValidator interface
        if (validator is ICommandQueryValidator<TRequest> commandQueryValidator)
        {
            _validator = commandQueryValidator;
        }
        
        throw new NotImplementedException($"{typeof(TRequest)} validator needs to implement {typeof(ICommandQueryValidator<TRequest>)}.");
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        return _validator.IsValid(request) ? next() : Errors(_validator.GetErrorsMessages());
    }

    private static Task<TResponse> Errors(IList<string> errors)
    {
        var response = CommandResult.Fail(errors);

        return Task.FromResult(response as TResponse);
    }
}