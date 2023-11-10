using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tareas.SharedComponents.Repositorio;
using Tareas.WEB;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Api Debugg
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7266/") });

//Api publicada
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:9050/") });

builder.Services.AddScoped<IRepository, Repository>();

await builder.Build().RunAsync();