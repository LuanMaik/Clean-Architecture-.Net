using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Infrastructure.Data.EntityFrameworkCore.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDataDependencies(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        
        return services;
    }
}