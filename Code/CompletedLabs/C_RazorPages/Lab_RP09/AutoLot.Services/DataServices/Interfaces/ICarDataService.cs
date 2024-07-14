﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - ICarDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/05/27
// ==================================

namespace AutoLot.Services.DataServices.Interfaces;

public interface ICarDataService : IDataServiceBase<Car>
{
    Task<IEnumerable<Car>> GetAllByMakeIdAsync(int? makeId);
}