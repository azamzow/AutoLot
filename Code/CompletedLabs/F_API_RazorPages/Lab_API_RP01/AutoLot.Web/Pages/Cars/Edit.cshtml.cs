// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Edit.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/30
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class EditModel(
    IAppLogging<EditModel> appLogging,
    ICarDataService dataService,
    IMakeDataService makeDataService)
    : BasePageModel<Car, EditModel>(appLogging, dataService, "Edit")
{
    public async Task OnGetAsync(int id)
    {
        await GetLookupValuesAsync();
        await GetOneAsync(id);
    }

    public async Task<IActionResult> OnPostAsync() 
        => await SaveWithLookupAsync(MainDataService.UpdateAsync);

    protected override async Task GetLookupValuesAsync()
    {
        LookupValues = new SelectList(await makeDataService.GetAllAsync(), nameof(Make.Id), nameof(Make.Name));
    }
}