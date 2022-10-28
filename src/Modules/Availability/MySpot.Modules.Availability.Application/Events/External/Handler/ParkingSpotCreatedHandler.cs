using System.Threading;
using System.Threading.Tasks;
using MySpot.Modules.Availability.Application.Commands;
using MySpot.Shared.Abstractions.Commands;
using MySpot.Shared.Abstractions.Events;

namespace MySpot.Modules.Availability.Application.Events.External.Handler;

public sealed class ParkingSpotCreatedHandler : IEventHandler<ParkingSpotCreated>
{
    private readonly ICommandDispatcher _commandDispatcher;

    public ParkingSpotCreatedHandler(ICommandDispatcher commandDispatcher)
        => _commandDispatcher = commandDispatcher;
    
    public async Task HandleAsync(ParkingSpotCreated @event, CancellationToken cancellationToken = default)
    {
        var command = new AddResource(@event.ParkingSpotId, 2, new[] {"parking_spot"});
        await _commandDispatcher.SendAsync(command, cancellationToken);
    }
}