// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor - IDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/07/11
// ==================================

namespace AutoLot.Blazor.Services.Interfaces;

public interface IDataService<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetEntityAsync(int id);
    Task<TEntity> AddEntityAsync(TEntity entity);
    Task<TEntity> UpdateEntityAsync(int id, TEntity entity);
    Task DeleteEntityAsync(TEntity entity);
    Task<List<TEntity>> GetAllEntitiesAsync();
}