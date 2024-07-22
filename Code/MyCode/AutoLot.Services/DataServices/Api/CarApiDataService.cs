namespace AutoLot.Services.DataServices.Api;
public class CarApiDataService( IAppLogging<CarApiDataService> appLogging, ICarApiServiceWrapper serviceWrapper) : ApiDataServiceBase<Car, CarApiDataService>(appLogging, serviceWrapper), ICarDataService
{
    public async Task<IEnumerable<Car>> GetAllByMakeIdAsync(int? makeId) => makeId.HasValue ? await ((ICarApiServiceWrapper)ServiceWrapper).GetCarsByMakeAsync(makeId.Value) : await GetAllAsync();
}