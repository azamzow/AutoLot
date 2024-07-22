namespace AutoLot.Web.Pages;
public class ValidationModel : PageModel
{
	[ViewData]
	public string Title => "Validation Example";
	[BindProperty]
	public AddToCartViewModelRp Entity { get; set; }
	public void OnGet()
	{
		Entity = new AddToCartViewModelRp { Id = 1, ItemId = 1, StockQuantity = 2, Quantity = 0 };
	}
	public IActionResult OnPost()
	{
		if (!ModelState.IsValid)
		{
			return Page();
		}
		return RedirectToPage("Validation");
	}
}