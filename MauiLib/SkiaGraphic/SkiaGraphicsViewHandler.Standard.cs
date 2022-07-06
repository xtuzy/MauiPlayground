#if NET && !__IOS__ && !__ANDROID__ && !WINDOWS
using Microsoft.Maui.Handlers;
using System;

namespace MauiLib.SkiaGraphic
{
	public partial class SkiaGraphicsViewHandler : ViewHandler<ISkiaGraphicsView, object>
	{
		protected override object CreatePlatformView() => throw new NotImplementedException();

		public static void MapDrawable(ISkiaGraphicsViewHandler handler, ISkiaGraphicsView graphicsView) { }
		public static void MapFlowDirection(ISkiaGraphicsViewHandler handler, ISkiaGraphicsView graphicsView) { }

		public static void MapInvalidate(ISkiaGraphicsViewHandler handler, ISkiaGraphicsView graphicsView, object? arg) { }
	}
}
#endif