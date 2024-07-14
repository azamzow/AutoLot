// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor - IBrowserStorageService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/07/11
// ==================================

namespace AutoLot.Blazor.Services.Storage.Interfaces;

public interface IBrowserStorageService
{
    Task SetItemAsync<T>(string key, T item);
    Task<T> GetItemAsync<T>(string key);
}