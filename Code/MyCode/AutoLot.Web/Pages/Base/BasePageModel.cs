using AutoLot.Services.DataServices.Interfaces.Base;

namespace AutoLot.Web.Pages.Base;

public abstract class BasePageModel<TEntity, TPageModel>(
IAppLogging<TPageModel> appLoggingInstance,
IDataServiceBase<TEntity> dataService, string pageTitle)
: PageModel where TEntity : BaseEntity, new()
{
    protected readonly IAppLogging<TPageModel> AppLoggingInstance = appLoggingInstance;
    protected readonly IDataServiceBase<TEntity> MainDataService = dataService;

	[ViewData]
	public string Title { get; init; } = pageTitle;

	[BindProperty]
	public TEntity Entity { get; set; }
	public SelectList LookupValues { get; set; }
	public string Error { get; set; }

    protected virtual Task GetLookupValuesAsync()
    {
        LookupValues = null;
        return Task.CompletedTask;
    }

    protected async Task GetOneAsync(int? id)
    {
        if (!id.HasValue)
        {
            Error = "Invalid request";
            Entity = null;
            return;
        }
        Entity = await MainDataService.FindAsync(id.Value);
        if (Entity == null)
        {
            Error = "Not found";
            return;
        }
        Error = string.Empty;
    }
    protected virtual async Task<IActionResult> SaveOneAsync(
    Func<TEntity, bool, Task<TEntity>> saveFunction)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        try
        {
            var savedEntity = await saveFunction(Entity, true);
            return RedirectToPage("./Details", new { id = savedEntity.Id });
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return HandleErrorReturnPage(ex);
        }
    }
    protected virtual async Task<IActionResult> SaveWithLookupAsync(
    Func<TEntity, bool, Task<TEntity>> saveFunction)
    {
        if (!ModelState.IsValid)
        {
            await GetLookupValuesAsync();
            return Page();
        }
        try
        {
            var savedEntity = await saveFunction(Entity, true);
            return RedirectToPage("./Details", new { id = savedEntity.Id });
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            await GetLookupValuesAsync();
            return HandleErrorReturnPage(ex);
        }
    }

    protected virtual async Task<IActionResult> DeleteOneAsync(int id)
    {
        try
        {
            await MainDataService.DeleteAsync(Entity);
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            ModelState.Clear();
            Entity = await MainDataService.FindAsync(id);
            return HandleErrorReturnPage(ex);
        }
    }

    internal IActionResult HandleErrorReturnPage(Exception ex)
	{
		Error = ex.Message;
		AppLoggingInstance.LogAppError(ex, "An error occurred");
		return Page();
	}
}
