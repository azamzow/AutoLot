namespace AutoLot.Api.Controllers;
public class DriversController(IAppLogging<DriversController> logger, IDriverRepo repo)
: BaseCrudController<Driver, DriversController>(logger, repo);