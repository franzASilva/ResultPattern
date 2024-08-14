using Microsoft.Extensions.DependencyInjection;
using ResultPattern.Domain.Services;
using ResultPattern.Domain.Services.Interfaces;

namespace ResultPattern.IoC;

public static class Bootstrapper
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDummyService, DummyService>();

        return services;
    }
}