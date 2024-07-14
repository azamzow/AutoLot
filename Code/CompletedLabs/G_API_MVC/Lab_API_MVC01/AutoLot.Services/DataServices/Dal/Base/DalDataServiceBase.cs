// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - DalDataServiceBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/30
// ==================================

namespace AutoLot.Services.DataServices.Dal.Base;

public abstract class DalDataServiceBase<TEntity, TDataService>(
    IAppLogging<TDataService> appLogging,
    IBaseRepo<TEntity> mainRepo)     : IDataServiceBase<TEntity>
    where TEntity : BaseEntity, new()
    where TDataService : class
{
    protected readonly IBaseRepo<TEntity> MainRepo = mainRepo;
    protected readonly IAppLogging<TDataService> AppLoggingInstance = appLogging;

    public Task<IEnumerable<TEntity>> GetAllAsync()
        => Task.FromResult(MainRepo.GetAllIgnoreQueryFilters());

    public Task<TEntity> FindAsync(int id) => Task.FromResult(MainRepo.Find(id));

    public Task<TEntity> UpdateAsync(TEntity entity, bool persist = true)
    {
        MainRepo.Update(entity, persist);
        return Task.FromResult(entity);
    }

    public Task DeleteAsync(TEntity entity, bool persist = true)
        => Task.FromResult(MainRepo.Delete(entity, persist));

    public Task<TEntity> AddAsync(TEntity entity, bool persist = true)
    {
        MainRepo.Add(entity, persist);
        return Task.FromResult(entity);
    }

    public void ResetChangeTracker()
    {
        MainRepo.Context.ChangeTracker.Clear();
    }
}
