// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor - MakeDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/07/11
// ==================================

namespace AutoLot.Blazor.Services;

public class MakeDataService : BaseDataService, IMakeDataService
{
    public async Task<Make> GetEntityAsync(int id) 
        => await Task.FromResult(Makes.FirstOrDefault(c => c.Id == id));
    public async Task<Make> AddEntityAsync(Make entity)
    {
        entity.Id = Makes.Max(x => x.Id)+1;
        Makes.Add(entity);
        return await Task.FromResult(entity);
    }
    public async Task<Make> UpdateEntityAsync(int id, Make entity) => await Task.FromResult(entity);
    public async Task DeleteEntityAsync(Make entity)
    {
        var carToRemove = Makes.FirstOrDefault(c => c.Id == entity.Id);
        if (carToRemove is not null)
        {
            Makes.Remove(carToRemove);
        }

        await Task.CompletedTask;
    }
    public async Task<List<Make>> GetAllEntitiesAsync() => await Task.FromResult(Makes);
}