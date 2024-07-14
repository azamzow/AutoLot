// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Create.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/05/27
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class CreateModel(
    IAppLogging<CreateModel> appLogging,
    ICarDataService dataService,
    IMakeDataService makeDataService)
    : BasePageModel<Car, CreateModel>(appLogging, dataService, "Create")
{
    public async Task OnGetAsync()
    {
        await GetLookupValuesAsync();
        Entity = new Car { IsDrivable = true };
    }
    public async Task<IActionResult> OnPostCreateNewCarAsync() 
        => await SaveWithLookupAsync( MainDataService.AddAsync);

    protected override async Task GetLookupValuesAsync()
    {
        LookupValues = new SelectList(await makeDataService.GetAllAsync(), nameof(Make.Id), nameof(Make.Name));
    }
}
