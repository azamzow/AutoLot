namespace AutoLot.Web.Pages.Cars;

public class IndexModel(IAppLogging<IndexModel> appLogging, ICarDataService dataService)
    : BasePageModel<Car, IndexModel>(appLogging, dataService, "Inventory")
{
    private readonly IAppLogging<IndexModel> _appLogging = appLogging;
    public string MakeName { get; set; }
    public int? MakeId { get; set; }
    public IEnumerable<Car> CarRecords { get; set; }
    public async Task OnGetAsync(int? makeId, string makeName)
    {
        if (!makeId.HasValue)
        {
            MakeName = "All Makes";
            CarRecords = await MainDataService.GetAllAsync();
            return;
        }
        MakeId = makeId;
        MakeName = makeName;
        CarRecords = await ((ICarDataService)MainDataService).GetAllByMakeIdAsync(makeId.Value);
    }
}