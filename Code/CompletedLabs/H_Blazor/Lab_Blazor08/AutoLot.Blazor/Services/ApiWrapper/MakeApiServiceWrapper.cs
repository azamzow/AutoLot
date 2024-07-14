// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor - MakeApiServiceWrapper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/07/11
// ==================================

namespace AutoLot.Blazor.Services.ApiWrapper;

public class MakeApiServiceWrapper(
    HttpClient client,
    IOptionsMonitor<ApiServiceSettings> apiSettingsMonitor)
    : ApiServiceWrapperBase<Make>(
            client, apiSettingsMonitor, apiSettingsMonitor.CurrentValue.MakeBaseUri),
        IMakeApiServiceWrapper;