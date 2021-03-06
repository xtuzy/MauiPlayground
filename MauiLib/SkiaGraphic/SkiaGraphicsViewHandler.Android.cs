#if __ANDROID__
using MauiLib.SkiaGraphic.Platforms;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.Maui.Graphics.Skia.Views;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace MauiLib.SkiaGraphic
{
	public partial class SkiaGraphicsViewHandler : ViewHandler<ISkiaGraphicsView, PlatformSkiaView>
	{
		protected override PlatformSkiaView CreatePlatformView() => new(Context);

		public static void MapDrawable(SkiaGraphicsViewHandler handler, ISkiaGraphicsView graphicsView)
		{
			handler.PlatformView?.UpdateDrawable(graphicsView);
		}

		public static void MapFlowDirection(SkiaGraphicsViewHandler handler, ISkiaGraphicsView graphicsView)
		{
			handler.PlatformView?.UpdateFlowDirection(graphicsView);
			handler.PlatformView?.Invalidate();
		}

		public static void MapInvalidate(SkiaGraphicsViewHandler handler, ISkiaGraphicsView graphicsView, object? arg)
		{
			handler.PlatformView?.Invalidate();
		}
	}
}
#endif