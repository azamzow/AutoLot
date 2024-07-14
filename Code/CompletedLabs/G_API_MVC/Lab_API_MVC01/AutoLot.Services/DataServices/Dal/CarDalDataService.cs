// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - CarDalDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/30
// ==================================

namespace AutoLot.Services.DataServices.Dal;

public class CarDalDataService(IAppLogging<CarDalDataService> appLogging, ICarRepo repo)
    : DalDataServiceBase<Car, CarDalDataService>(appLogging, repo), ICarDataService
{
    public Task<IEnumerable<Car>> GetAllByMakeIdAsync(int? makeId) 
        =>  Task.FromResult(makeId.HasValue 
            ? repo.GetAllBy(makeId.Value) 
            : MainRepo.GetAllIgnoreQueryFilters());
}