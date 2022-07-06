#if __TIZEN__
using Microsoft.Maui.Platform;

namespace MauiLib.SkiaGraphic
{
	public partial class SkiaGraphicsViewHandler : ViewHandler<ISkiaGraphicsView, PlatformSkiaView>
	{
		protected override PlatformSkiaView CreatePlatformView() => new PlatformSkiaView(PlatformParent);

		public static void MapDrawable(IGraphicsViewHandler handler, ISkiaGraphicsView graphicsView)
		{
			handler.PlatformView?.UpdateDrawable(graphicsView);
		}

		public static void MapFlowDirection(IGraphicsViewHandler handler, ISkiaGraphicsView graphicsView)
		{
			handler.PlatformView?.UpdateFlowDirection(graphicsView);
			handler.PlatformView?.Invalidate();
		}

		public static void MapInvalidate(IGraphicsViewHandler handler, ISkiaGraphicsView graphicsView, object? arg)
		{
			handler.PlatformView?.Invalidate();
		}
	}
}
#endif