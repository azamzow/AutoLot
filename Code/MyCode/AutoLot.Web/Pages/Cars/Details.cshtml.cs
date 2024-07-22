namespace AutoLot.Web.Pages.Cars;
public class DetailsModel(IAppLogging<DetailsModel> appLogging, ICarDataService dataService)
: BasePageModel<Car, DetailsModel>(appLogging, dataService, "Details")
{
    public async Task OnGetAsync(int? id) => await GetOneAsync(id);
}