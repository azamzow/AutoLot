namespace AutoLot.Api.Controllers;
public class MakesController(IAppLogging<MakesController> logger, IMakeRepo repo)
: BaseCrudController<Make, MakesController>(logger, repo);