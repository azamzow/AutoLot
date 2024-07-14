// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - ServiceConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/30
// ==================================

namespace AutoLot.Services.ApiWrapper.Configuration;
public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureApiServiceWrapper(
        this IServiceCollection services, IConfiguration config)
    {
        services.Configure<ApiServiceSettings>(config.GetSection(nameof(ApiServiceSettings)));
        services.AddHttpClient<ICarApiServiceWrapper, CarApiServiceWrapper>();
        services.AddHttpClient<IMakeApiServiceWrapper, MakeApiServiceWrapper>();
        return services;
    }
}
