namespace AutoLot.Api.Controllers;
public class RadiosController(IAppLogging<RadiosController> logger, IRadioRepo repo)
: BaseCrudController<Radio, RadiosController>(logger, repo);