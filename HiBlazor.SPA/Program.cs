using AutoMapper;
using Blazored.SessionStorage;
using HiBlazor.SPA;
using HiBlazor.SPA.Authorization;
using HiBlazor.SPA.Helpers;
using HiBlazor.SPA.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IJwtUtils, JwtUtils>();
var mapperConfiguration = new MapperConfiguration(configuration =>
{
    configuration.AddProfile(new AutoMapperProfile());
});

var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddRadzenComponents();
builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<ReservationService>();
builder.Services.AddSingleton<DataContext>();
builder.Services.AddBlazoredSessionStorageAsSingleton();

await builder.Build().RunAsync();
