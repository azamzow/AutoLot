namespace AutoLot.Web.Pages;

public class RazorSyntaxModel(ICarDataService dataService, IMakeDataService makeDataService) : PageModel
{
    [ViewData]
    public SelectList LookupValues { get; set; }

    [ViewData]
    public string Title => "Razor Syntax";
    [BindProperty]
    public Car Entity { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        LookupValues = new(await makeDataService.GetAllAsync(), nameof(Make.Id), nameof(Make.Name));
        Entity = await dataService.FindAsync(6);
        return Page();
    }
}
