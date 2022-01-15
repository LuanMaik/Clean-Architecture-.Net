using CleanArchitecture.Application.Common;

namespace CleanArchitecture.Application.Bus.Interfaces;

public interface IBusService
{
    public Task<TResponse> SendCommand<TResponse>(ICommand<TResponse> request, CancellationToken cancellationToken = default);
}