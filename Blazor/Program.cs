using Blazor;
using Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(sp => new HttpClient
{
    //BaseAddress = new Uri("https://localhost:7057/") // URL de tu API
    BaseAddress = new Uri("https://curso2025-001-site1.anytempurl.com/") // URL de tu API
});
builder.Services.AddScoped<CiudadanoService>();
builder.Services.AddScoped<GeneroService>();

await builder.Build().RunAsync();
