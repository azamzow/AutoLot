namespace AutoLot.Blazor.Services.Storage;
public class SessionStorageService(IJSRuntime jsRuntime) : IBrowserStorageService
{
	public async Task SetItemAsync<T>(string key, T item)
	{
		await jsRuntime.InvokeVoidAsync(
		"skimedicInterop.setSessionStorage", key, JsonSerializer.Serialize(item));
	}
	public async Task<T> GetItemAsync<T>(string key)
	{
		var json = await jsRuntime.InvokeAsync<string>("skimedicInterop.getSessionStorage", key);
		return json == null ? default : JsonSerializer.Deserialize<T>(json);
	}
}