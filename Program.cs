using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EventEaseApp;
using EventEaseApp.Services;
using EventEaseApp.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddLogging();
builder.Services.AddSingleton<EventServices>();
builder.Services.AddScoped<EventServices>();
builder.Services.AddScoped<UserSessionModel>();
builder.Services.AddScoped<EventCardModel>();
builder.Services.AddScoped<AttendanceService>();

await builder.Build().RunAsync();
