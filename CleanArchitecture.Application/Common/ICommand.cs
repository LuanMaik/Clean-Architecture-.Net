using CleanArchitecture.Application.Interfaces.CommandQuery;
using MediatR;

namespace CleanArchitecture.Application.Common;

public interface ICommand<out T> : IRequest<T>
{
}