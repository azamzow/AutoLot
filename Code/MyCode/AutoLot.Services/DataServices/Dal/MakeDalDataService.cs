namespace AutoLot.Services.DataServices.Dal;
public class MakeDalDataService(IAppLogging<MakeDalDataService> appLogging, IMakeRepo repo)
: DalDataServiceBase<Make, MakeDalDataService>(appLogging, repo), IMakeDataService;