using MediatR;

namespace CleanArchitecture.Application.Bus.Commands;

public interface ICommandHandler<in TRequest, TResponse>: IRequestHandler<TRequest, TResponse> where TRequest: ICommand<TResponse>
{
    
}