namespace AutoLot.Api.Controllers;
public class CarDriversController(IAppLogging<CarDriversController> logger, ICarDriverRepo repo)
: BaseCrudController<CarDriver, CarDriversController>(logger, repo);