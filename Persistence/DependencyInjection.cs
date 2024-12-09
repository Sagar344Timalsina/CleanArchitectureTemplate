using Domain.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Repositories;
using System;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceDI(this IServiceCollection services, IConfiguration configuration)
    {
        var resilienceSettings = configuration.GetSection("ResilienceSettings");

        var maxRetryCount = Convert.ToInt32(resilienceSettings["MaxRetryCount"]);
        var maxRetryDelay = TimeSpan.FromSeconds(Convert.ToInt32(resilienceSettings["MaxRetryDelayInSeconds"]));
        var enableRetryOnFailure = true;

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
            {
                if (enableRetryOnFailure)
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: maxRetryCount,
                        maxRetryDelay: maxRetryDelay,
                        errorNumbersToAdd: null);
                }
            });
        });
        services.AddScoped<IUserRepositories,UserRepository>();
        services.AddScoped<IPasswordHasher,PasswordHasher>();

        return services;
    }
}