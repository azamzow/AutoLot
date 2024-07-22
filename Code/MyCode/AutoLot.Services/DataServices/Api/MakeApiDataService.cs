﻿namespace AutoLot.Services.DataServices.Api;
public class MakeApiDataService(IAppLogging<MakeApiDataService> appLogging, IMakeApiServiceWrapper serviceWrapper) : ApiDataServiceBase<Make, MakeApiDataService>(appLogging, serviceWrapper), IMakeDataService;