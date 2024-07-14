// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor - LocalStorageService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/07/07
// ==================================

namespace AutoLot.Blazor.Services.Storage;

public class LocalStorageService(IJSRuntime jsRuntime) : IBrowserStorageService
{
    public async Task SetItemAsync<T>(string key, T item)
    {
        await jsRuntime.InvokeVoidAsync(
            "skimedicInterop.setLocalStorage", key, JsonSerializer.Serialize(item));
    }

    public async Task<T> GetItemAsync<T>(string key)
    {
        var json = await jsRuntime.InvokeAsync<string>("skimedicInterop.getLocalStorage", key);
        return json == null ? default : JsonSerializer.Deserialize<T>(json);
    }
}