using CommunityToolkit.Maui;
using MiApp.Services;
using MiApp.ViewModels;
using MiApp.Views;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace MiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseSkiaSharp()

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });



            Routing.RegisterRoute(nameof(CalcularIMCPage), typeof(CalcularIMCPage));

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://curso2025-001-site1.anytempurl.com/") // URL de tu API
            });
            builder.Services.AddScoped<CiudadanoService>();
            builder.Services.AddScoped<GeneroService>();

            builder.Services.AddSingleton<CiudadanosPage>();
            builder.Services.AddSingleton<CiudadanosViewModel>();

            builder.Services.AddTransientWithShellRoute<CiudadanoPage, CiudadanoViewModel>(nameof(CiudadanoPage));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
