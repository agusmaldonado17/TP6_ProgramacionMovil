using Microsoft.Extensions.Logging;
using TP6ProgramacionMovil.Services;

namespace TP6ProgramacionMovil
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

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://tp3backend.runasp.net/")
            });

            builder.Services.AddScoped<AuthService>();

            return builder.Build();
        }
    }
}
