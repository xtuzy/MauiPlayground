using View = MauiPlayground.CustomControls.DrawableView.DrawableView;
using ViewHandler = MauiPlayground.CustomControls.DrawableView.DrawableViewHandler;
namespace MauiPlayground.CustomControls.Hosting
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
