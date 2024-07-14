// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor - CarApiDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/07/11
// ==================================

namespace AutoLot.Blazor.Services;

public class CarApiDataService(ICarApiServiceWrapper serviceWrapper) : ICarDataService
{
    internal Car CreateCleanCar(Car entity)
    {
        return new Car
        {
            Color = entity.Color,
            DateBuilt = entity.DateBuilt,
            Id = entity.Id,
            TimeStamp = entity.TimeStamp,
            IsDrivable = entity.IsDrivable,
            MakeId = entity.MakeId,
            PetName = entity.PetName,
            Price = entity.Price
        };
    }

    public async Task<Car> GetEntityAsync(int id) => await serviceWrapper.GetEntityAsync(id);

    public async Task<Car> AddEntityAsync(Car entity)
        => await serviceWrapper.AddEntityAsync(CreateCleanCar(entity));

    public async Task<Car> UpdateEntityAsync(int id, Car entity)
        => await serviceWrapper.UpdateEntityAsync(CreateCleanCar(entity));

    public async Task DeleteEntityAsync(Car entity)
    {
        await serviceWrapper.DeleteEntityAsync(CreateCleanCar(entity));
    }

    public async Task<List<Car>> GetAllEntitiesAsync()
        => (await serviceWrapper.GetAllEntitiesAsync()).ToList();

    public async Task<List<Car>> GetByMakeAsync(int makeId)
        => (await serviceWrapper.GetCarsByMakeAsync(makeId)).ToList();
}