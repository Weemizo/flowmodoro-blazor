using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FlowmodoroTimer;
using FlowmodoroTimer.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<flowmodoro_blazor.App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<TimerService>();
builder.Services.AddScoped<SettingsService>();

await builder.Build().RunAsync();
