namespace AutoLot.Web.Pages;
public class SimpleServiceModel : PageModel
{
	public string Message { get; set; }
	public void OnGetServiceOne([FromKeyedServices(nameof(SimpleServiceOne))] ISimpleService service)
	{
		Message = service.SayHello();
	}
	public void OnGetServiceTwo([FromKeyedServices(nameof(SimpleServiceTwo))] ISimpleService service)
	{
		Message = service.SayHello();
	}
}