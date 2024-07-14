// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - ApiDataServiceBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/30
// ==================================

namespace AutoLot.Services.DataServices.Api.Base;
public abstract class ApiDataServiceBase<TEntity, TDataService>(
    IAppLogging<TDataService> appLogging,
    IApiServiceWrapperBase<TEntity> serviceWrapperBase)
    : IDataServiceBase<TEntity>
    where TEntity : BaseEntity, new()
    where TDataService : class
{
    protected readonly IApiServiceWrapperBase<TEntity> ServiceWrapper = serviceWrapperBase;
    protected readonly IAppLogging<TDataService> AppLoggingInstance = appLogging;

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await ServiceWrapper.GetAllEntitiesAsync();
    public async Task<TEntity> FindAsync(int id)
        => await ServiceWrapper.GetEntityAsync(id);
    public async Task<TEntity> UpdateAsync(TEntity entity, bool persist = true)
        => await ServiceWrapper.UpdateEntityAsync(entity);
    public async Task DeleteAsync(TEntity entity, bool persist = true)
        => await ServiceWrapper.DeleteEntityAsync(entity);
    public async Task<TEntity> AddAsync(TEntity entity, bool persist = true)
        => await ServiceWrapper.AddEntityAsync(entity);

}
