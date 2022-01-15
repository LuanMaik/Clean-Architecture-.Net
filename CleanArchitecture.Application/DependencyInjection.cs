using CleanArchitecture.Application.Bus;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        // Add MediatR and Handlers that implements IRequestHandler
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        
        // Add the wraper bus service to MediatR 
        services.AddScoped<IBusService, BusMediatorService>();
        
        // Add FluentValidation validators registrations
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        
        return services;
    }
}