using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.Extensions.Logging;
using Tareas.Mobile.Data;
using Tareas.SharedComponents.Repositorio;

namespace Tareas.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7266/") });
            //API SALES PARA PRUEBAS
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://192.168.1.143:9040/") });
            
            //Conexión a api localhost
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5003/") });

            //Conexión a api corriendo en IIS
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://192.168.1.143:9050/") });
            
            //Conexión a api para android en dispositivo físico
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5003/") });
            
            //Conexión a api para android en emulador
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://10.0.2.2:5003/") });

            builder.Services.AddScoped<IRepository, Repository>();

            builder.Services.AddSweetAlert2();
            return builder.Build();
        }
    }
}