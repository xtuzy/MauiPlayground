#if WINDOWS
using MauiLib.SkiaGraphic.Platforms;
using Microsoft.Maui.Graphics.Win2D;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Microsoft.UI.Xaml;

namespace MauiLib.SkiaGraphic
{
    public partial class SkiaGraphicsViewHandler : ViewHandler<ISkiaGraphicsView, PlatformSkiaView>
    {
        protected override PlatformSkiaView CreatePlatformView()
        {
            return new PlatformSkiaView();
        }

        public static void MapDrawable(ISkiaGraphicsViewHandler handler, ISkiaGraphicsView graphicsView)
        {
            handler.PlatformView?.UpdateDrawable(graphicsView);
        }

        public static void MapFlowDirection(ISkiaGraphicsViewHandler handler, ISkiaGraphicsView graphicsView)
        {
            handler.PlatformView?.UpdateFlowDirection(graphicsView);
            handler.PlatformView?.Invalidate();
        }

        public static void MapInvalidate(ISkiaGraphicsViewHandler handler, ISkiaGraphicsView graphicsView, object? arg)
        {
            handler.PlatformView?.Invalidate();
        }
    }
}
#endif