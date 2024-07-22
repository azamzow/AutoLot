namespace AutoLot.Blazor.Services;
public class MakeApiDataService(IMakeApiServiceWrapper serviceWrapper) : IMakeDataService
{
	public async Task<Make> GetEntityAsync(int id) => await serviceWrapper.GetEntityAsync(id);
	public async Task<Make> AddEntityAsync(Make entity)
	=> await serviceWrapper.AddEntityAsync(entity);
	public async Task<Make> UpdateEntityAsync(int id, Make entity)
	=> await serviceWrapper.UpdateEntityAsync(entity);
	public async Task DeleteEntityAsync(Make entity)
	{
		await serviceWrapper.DeleteEntityAsync(entity);
	}
	public async Task<List<Make>> GetAllEntitiesAsync()
	=> (await serviceWrapper.GetAllEntitiesAsync()).ToList();
}