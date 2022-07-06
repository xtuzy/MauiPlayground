using MauiLib.CustomControls.Hosting;
using MauiLib.SkiaGraphic;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace MauiPlayground
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDrawableView()
                .UseSkiaSharp()
                .UseSkiaGraphicsView()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            return builder.Build();
        }
    }
}