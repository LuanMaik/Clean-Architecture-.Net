using CleanArchitecture.Application.Interfaces.CommandQuery;
using FluentValidation;
using MediatR;
using ValidationException = CleanArchitecture.Application.Exceptions.ValidationException;

namespace CleanArchitecture.Application.Bus.Behaviors;

public class RequestValidationBehavior<TRequest, TResponse> : MediatR.IPipelineBehavior<TRequest, TResponse> where TRequest : Interfaces.IRequest<TResponse>
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
        if (_validator.IsValid(request) == false)
            return CommandResult<TResponse>.Fail(null, _validator.GetErrorsMessages());


        //throw new ValidationException(_validator.GetErrorsMessages());

        return next();
    }
}