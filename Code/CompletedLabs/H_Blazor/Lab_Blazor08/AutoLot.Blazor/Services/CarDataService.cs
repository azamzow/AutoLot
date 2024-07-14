// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor - CarDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/07/11
// ==================================

namespace AutoLot.Blazor.Services;

public class CarDataService : BaseDataService, ICarDataService
{
    public async Task<Car> GetEntityAsync(int id)
        => await Task.FromResult(CarList.FirstOrDefault(c => c.Id == id));

    public async Task<Car> AddEntityAsync(Car entity)
    {
        entity.Id = CarList.Max(x => x.Id) + 1;
        entity.MakeNavigation = Makes.First(m => m.Id == entity.MakeId);
        CarList.Add(entity);
        return await Task.FromResult(entity);
    }

    public async Task<Car> UpdateEntityAsync(int id, Car entity)
    {
        entity.MakeNavigation = Makes.First(m => m.Id == entity.MakeId);
        return await Task.FromResult(entity);
    }

    public async Task DeleteEntityAsync(Car entity)
    {
        var carToRemove = CarList.FirstOrDefault(c => c.Id == entity.Id);
        if (carToRemove is not null)
        {
            CarList.Remove(carToRemove);
        }
        await Task.CompletedTask;
    }

    public async Task<List<Car>> GetAllEntitiesAsync() => await Task.FromResult(CarList);

    public async Task<List<Car>> GetByMakeAsync(int makeId)
        => await Task.FromResult(CarList.Where(x => x.MakeId == makeId).ToList());
}