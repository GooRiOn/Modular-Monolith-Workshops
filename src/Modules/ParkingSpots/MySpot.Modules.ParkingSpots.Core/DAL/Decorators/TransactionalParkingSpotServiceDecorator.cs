using MySpot.Modules.ParkingSpots.Core.Entities;
using MySpot.Modules.ParkingSpots.Core.Services;

namespace MySpot.Modules.ParkingSpots.Core.DAL.Decorators;

internal sealed class TransactionalParkingSpotServiceDecorator : IParkingSpotsService
{
    private readonly IParkingSpotsService _parkingSpotsService;
    private readonly ParkingSpotsUnitOfWork _unitOfWork;

    public TransactionalParkingSpotServiceDecorator(IParkingSpotsService parkingSpotsService, 
        ParkingSpotsUnitOfWork unitOfWork)
    {
        _parkingSpotsService = parkingSpotsService;
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<ParkingSpot>> GetAllAsync() => _parkingSpotsService.GetAllAsync();

    public async Task AddAsync(ParkingSpot parkingSpot)
    {
        await _unitOfWork.ExecuteAsync(async () => await _parkingSpotsService.AddAsync(parkingSpot));
    }

    public async Task UpdateAsync(ParkingSpot parkingSpot)
    {
        await _unitOfWork.ExecuteAsync(async () => await _parkingSpotsService.UpdateAsync(parkingSpot));
    }

    public async Task DeleteAsync(Guid parkingSpotId)
    {
        await _unitOfWork.ExecuteAsync(async () => await _parkingSpotsService.DeleteAsync(parkingSpotId));
    }
}