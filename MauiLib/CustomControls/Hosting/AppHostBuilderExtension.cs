using View = MauiLib.CustomControls.DrawableView.DrawableView;
using ViewHandler = MauiLib.CustomControls.DrawableView.DrawableViewHandler;
namespace MauiLib.CustomControls.Hosting
{
    public static class AppHostBuilderExtension
    {
        public static MauiAppBuilder UseDrawableView(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(handlers =>
            {
                handlers.AddTransient(typeof(View), typeof(ViewHandler));
            });

            return builder;
        }
    }
}
