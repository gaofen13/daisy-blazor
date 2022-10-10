using DaisyBlazor;
using DaisyBlazor.Shared;
using DaisyBlazor.Shared.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddDaisyBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

await builder.Build().RunAsync();
