using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Modules.ParkingSpots.Core.Clients;
using MySpot.Modules.ParkingSpots.Core.DAL;
using MySpot.Modules.ParkingSpots.Core.DAL.Decorators;
using MySpot.Modules.ParkingSpots.Core.Services;
using MySpot.Shared.Abstractions.Commands;
using MySpot.Shared.Infrastructure.Messaging.Outbox;
using MySpot.Shared.Infrastructure.Postgres;

[assembly: InternalsVisibleTo("MySpot.Modules.ParkingSpots.Api")]

namespace MySpot.Modules.ParkingSpots.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSingleton<IAvailabilityApiClient, AvailabilityApiClient>()
            .AddScoped<IParkingSpotsService, ParkingSpotsService>()
            .AddPostgres<ParkingSpotsDbContext>(configuration)
            .AddUnitOfWork<ParkingSpotsUnitOfWork>()
            .AddOutbox<ParkingSpotsDbContext>(configuration);

        services.TryDecorate<IParkingSpotsService, TransactionalParkingSpotServiceDecorator>();

        return services;
    }
}