namespace AutoLot.Web.Areas.Admin.Pages.Makes;
public class DetailsModel(IAppLogging<DetailsModel> appLogging, IMakeDataService dataService)
    : BasePageModel<Make, DetailsModel>(appLogging, dataService, "Details")
{
    public async Task OnGetAsync(int? id) => await GetOneAsync(id);
}