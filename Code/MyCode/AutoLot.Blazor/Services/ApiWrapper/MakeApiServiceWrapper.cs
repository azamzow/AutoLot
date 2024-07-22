﻿public class MakeApiServiceWrapper(
HttpClient client, IOptionsMonitor<ApiServiceSettings> apiSettingsMonitor)
: ApiServiceWrapperBase<Make>(
client, apiSettingsMonitor, apiSettingsMonitor.CurrentValue.MakeBaseUri),
IMakeApiServiceWrapper;