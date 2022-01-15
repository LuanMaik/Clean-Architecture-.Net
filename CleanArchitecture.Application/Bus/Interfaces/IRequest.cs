namespace CleanArchitecture.Application.Bus.Interfaces;

/// <summary>
/// Anti-corruption Layer to use MediatR.IRequest interface
/// </summary>
public interface IRequest<out TResponse>: MediatR.IRequest<TResponse>
{
}