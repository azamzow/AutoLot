namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class IndexModel(IAppLogging<IndexModel> appLogging, IMakeDataService dataService) : PageModel
{
    [ViewData]
    public string Title => "Makes";

    public IEnumerable<Make> MakeRecords { get; set; }
    public async Task OnGetAsync() => MakeRecords = await dataService.GetAllAsync();
}
