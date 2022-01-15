namespace CleanArchitecture.Application.Bus.Interfaces;

public interface IBusService
{
    public Task<TResponse> SendCommand<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}