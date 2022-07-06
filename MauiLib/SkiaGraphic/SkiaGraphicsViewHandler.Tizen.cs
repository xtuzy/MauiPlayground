#if __TIZEN__
using Microsoft.Maui.Platform;

namespace MauiLib.SkiaGraphic
{
	public partial class SkiaGraphicsViewHandler : ViewHandler<ISkiaGraphicsView, PlatformSkiaView>
	{
		protected override PlatformSkiaView CreatePlatformView() => new PlatformSkiaView(PlatformParent);

		public static void MapDrawable(GraphicsViewHandler handler, ISkiaGraphicsView graphicsView)
		{
			handler.PlatformView?.UpdateDrawable(graphicsView);
		}

		public static void MapFlowDirection(GraphicsViewHandler handler, ISkiaGraphicsView graphicsView)
		{
			handler.PlatformView?.UpdateFlowDirection(graphicsView);
			handler.PlatformView?.Invalidate();
		}

		public static void MapInvalidate(GraphicsViewHandler handler, ISkiaGraphicsView graphicsView, object? arg)
		{
			handler.PlatformView?.Invalidate();
		}
	}
}
#endif