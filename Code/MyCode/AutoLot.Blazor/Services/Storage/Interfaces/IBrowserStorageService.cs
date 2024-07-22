namespace AutoLot.Blazor.Services.Storage.Interfaces;
public interface IBrowserStorageService
{
	Task SetItemAsync<T>(string key, T item);
	Task<T> GetItemAsync<T>(string key);
}