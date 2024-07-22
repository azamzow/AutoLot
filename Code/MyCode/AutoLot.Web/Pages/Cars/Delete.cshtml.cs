namespace AutoLot.Web.Pages.Cars;
public class DeleteModel(IAppLogging<DeleteModel> appLogging, ICarDataService dataService)
: BasePageModel<Car, DeleteModel>(appLogging, dataService, "Delete")
{
    public async Task OnGetAsync(int? id)
    {
        if (!id.HasValue)
        {
            Error = "Invalid request";
            Entity = null;
            return;
        }
        await GetOneAsync(id);
    }
    public async Task<IActionResult> OnPostAsync(int id) => await DeleteOneAsync(id);
}