namespace AutoLot.Web.ViewComponents;
public class MenuViewComponent(IMakeDataService dataService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var makes = (await dataService.GetAllAsync()).ToList();
        if (!makes.Any())
        {
            return new ContentViewComponentResult("Unable to get the makes");
        }
        return View("MenuView", makes);
    }
}