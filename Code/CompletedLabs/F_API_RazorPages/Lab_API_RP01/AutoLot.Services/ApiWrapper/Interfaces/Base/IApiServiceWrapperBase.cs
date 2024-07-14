// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - IApiServiceWrapperBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/30
// ==================================

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AutoLot.Services.ApiWrapper.Interfaces.Base;
public interface IApiServiceWrapperBase<TEntity> where TEntity : BaseEntity, new()
{
    Task<IList<TEntity>> GetAllEntitiesAsync();
    Task<TEntity> GetEntityAsync(int id);
    Task<TEntity> AddEntityAsync(TEntity entity);
    Task<TEntity> UpdateEntityAsync(TEntity entity);
    Task DeleteEntityAsync(TEntity entity);
}