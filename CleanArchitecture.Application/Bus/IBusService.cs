using CleanArchitecture.Application.Bus.Commands;

namespace CleanArchitecture.Application.Bus;

public interface IBusService
{
    public Task<TResponse> SendCommand<TResponse>(ICommand<TResponse> request, CancellationToken cancellationToken = default);
}