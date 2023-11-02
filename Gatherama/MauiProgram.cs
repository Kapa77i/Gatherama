using Gatherama.Data;
using Gatherama.Services;
using Gatherama.Shared;
using Microsoft.Extensions.Logging;

namespace Gatherama
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
                })
                .UseMauiMaps();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddTransient<ApiService>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://gatheramaapi.azurewebsites.net") });
            //builder.Services.AddBlazorBootstrap(); // Add this line EI TOIMI!!!!
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();
            
            return builder.Build();
        }
    }
}