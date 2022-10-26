using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MySpot.Modules.Cleaning.Api;

public static class Extensions
{
    public static IServiceCollection AddCleaning(this IServiceCollection services)
    {
        return services;
    }

    public static IApplicationBuilder UseCleaning(this IApplicationBuilder app)
    {
        return app;
    }
}