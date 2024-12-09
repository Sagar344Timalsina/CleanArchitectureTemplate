using Application.Common;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
         cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));
        return services;   
    }
}