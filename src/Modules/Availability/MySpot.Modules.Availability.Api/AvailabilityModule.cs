using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Modules.Availability.Application;
using MySpot.Modules.Availability.Application.Commands;
using MySpot.Modules.Availability.Infrastructure;
using MySpot.Shared.Abstractions.Commands;
using MySpot.Shared.Abstractions.Dispatchers;
using MySpot.Shared.Abstractions.Modules;
using MySpot.Shared.Infrastructure.Modules;

namespace MySpot.Modules.Availability.Api;

internal sealed class AvailabilityModule : IModule
{
    public string Name { get; } = "Availability";
        
    public IEnumerable<string> Policies { get; } = new[]
    {
        "availability"
    };

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication().AddInfrastructure(configuration);
    }
        
    public void Use(IApplicationBuilder app)
    {
        app.UseModuleRequests()
            .Subscribe<AddResource>("availability/resources/add", async (command, serviceProvider, token) =>
            {
                var commandDispatcher = serviceProvider.GetRequiredService<ICommandDispatcher>();
                await commandDispatcher.SendAsync(command, token);
            });
    }

    public void Expose(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/resources", async (AddResource command, IDispatcher dispatcher) =>
        {
            await dispatcher.SendAsync(command);
            return Results.NoContent();
        }).WithTags("Resources").WithName("Add resource");
    }
}