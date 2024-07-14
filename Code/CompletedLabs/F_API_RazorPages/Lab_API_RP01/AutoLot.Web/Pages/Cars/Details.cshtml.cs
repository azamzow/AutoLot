// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Details.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/30
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class DetailsModel(IAppLogging<DetailsModel> appLogging, ICarDataService dataService)
    : BasePageModel<Car, DetailsModel>(appLogging, dataService, "Details")
{
    public async Task OnGetAsync(int? id) => await GetOneAsync(id);
}