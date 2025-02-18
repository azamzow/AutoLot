namespace AutoLot.Web.Areas.Admin.Pages.Makes;
public class DeleteModel(IAppLogging<DeleteModel> appLogging, IMakeDataService dataService)
    : BasePageModel<Make, DeleteModel>(appLogging, dataService, "Delete")
{
    public async Task OnGetAsync(int? id) => await GetOneAsync(id);
    public async Task<IActionResult> OnPostAsync(int id) => await DeleteOneAsync(id);
}