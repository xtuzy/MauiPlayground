using CpuView = MauiLib.CustomControls.DrawableView.DrawableView;
using CpuViewHandler = MauiLib.CustomControls.DrawableView.DrawableViewHandler;
namespace MauiLib.CustomControls.Hosting
{
    public static class AppHostBuilderExtension
    {
        public static MauiAppBuilder UseDrawableView(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(handlers =>
            {
                handlers.AddTransient(typeof(CpuView), typeof(CpuViewHandler));
            });

            return builder;
        }
    }
}
