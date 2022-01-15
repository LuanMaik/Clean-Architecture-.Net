namespace CleanArchitecture.Application.Bus.Interfaces;

/// <summary>
/// Anti-corruption Layer to use MediatR.IRequestHandler interface
/// </summary>
public interface IRequestHandler<in TRequest, TResponse>: MediatR.IRequestHandler<TRequest, TResponse> where TRequest: IRequest<TResponse>
{
    new Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}