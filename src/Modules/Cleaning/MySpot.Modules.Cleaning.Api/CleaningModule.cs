using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Shared.Abstractions.Modules;

namespace MySpot.Modules.Cleaning.Api;

internal sealed class CleaningModule : IModule
{
    public string Name { get; } = "Cleaning";
    
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
    }

    public void Use(IApplicationBuilder app)
    {
    }

    public void Expose(IEndpointRouteBuilder endpoints)
    {
    }
}