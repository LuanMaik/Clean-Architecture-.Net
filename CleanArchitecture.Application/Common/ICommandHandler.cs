using MediatR;

namespace CleanArchitecture.Application.Common;

public interface ICommandHandler<in TRequest, TResponse>: IRequestHandler<TRequest, TResponse> where TRequest: ICommand<TResponse>
{
    
}
// public interface ICommandHandler<in TRequest, TResponse> where TRequest : ICommand<TResponse>, IRequestHandler<TRequest, TResponse>
// {
//     
// }