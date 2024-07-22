namespace AutoLot.Web.Pages;

public class IndexModel(IAppLogging<IndexModel> logger, IOptionsMonitor<DealerInfo> dealerOptionsMonitor) : PageModel
{
    [BindProperty]
    public DealerInfo Entity { get; } = dealerOptionsMonitor.CurrentValue;

    public void OnGet()
    {
        //logger.LogAppError("Test Error");
    }
}
