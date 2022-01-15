using MediatR;

namespace CleanArchitecture.Application.Bus.Commands;

public interface ICommand<out T> : IRequest<T>
{
}