// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor - Program.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/07/07
// ==================================

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AutoLot.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ICarDataService, CarDataService>();
builder.Services.AddScoped<IMakeDataService, MakeDataService>();
builder.Services.Configure<DealerInfo>(builder.Configuration.GetSection(nameof(DealerInfo)));

await builder.Build().RunAsync();
