// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor - ICarDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/07/07
// ==================================

namespace AutoLot.Blazor.Services.Interfaces;

public interface ICarDataService : IDataService<Car>
{
    Task<List<Car>> GetByMakeAsync(int makeId);
}