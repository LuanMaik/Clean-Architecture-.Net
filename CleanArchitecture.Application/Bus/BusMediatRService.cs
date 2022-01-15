using CleanArchitecture.Application.Bus.Interfaces;
using CleanArchitecture.Application.Common;

namespace CleanArchitecture.Application.Bus;

/// <summary>
/// Anti-corruption Layer to use MediatR
/// </summary>
public class BusMediatorService: IBusService
{
    private readonly MediatR.IMediator _mediator;

    public BusMediatorService(MediatR.IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<TResponse> SendCommand<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send<TResponse>(command, cancellationToken);
    }
}