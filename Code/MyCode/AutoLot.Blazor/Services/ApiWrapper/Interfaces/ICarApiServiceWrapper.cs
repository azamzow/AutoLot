namespace AutoLot.Blazor.Services.ApiWrapper.Interfaces;
public interface ICarApiServiceWrapper : IApiServiceWrapperBase<Car>
{
	Task<IList<Car>> GetCarsByMakeAsync(int id);
}