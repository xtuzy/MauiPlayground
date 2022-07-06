#nullable enable
#if __IOS__ || MACCATALYST || MONOANDROID || WINDOWS || TIZEN || __ANDROID__
#define PLATFORM
using Microsoft.Maui.Handlers;
using PlatformView = MauiLib.SkiaGraphic.Platforms.PlatformSkiaView;
#else
using Microsoft.Maui.Handlers;
using PlatformView = System.Object;
#endif

namespace MauiLib.SkiaGraphic
{
    public partial class SkiaGraphicsViewHandler
    {
        public static IPropertyMapper<ISkiaGraphicsView, SkiaGraphicsViewHandler> Mapper = new PropertyMapper<ISkiaGraphicsView, SkiaGraphicsViewHandler>(ViewHandler.ViewMapper)
        {
            [nameof(ISkiaGraphicsView.Drawable)] = MapDrawable,
            [nameof(IView.FlowDirection)] = MapFlowDirection
        };

        public static CommandMapper<ISkiaGraphicsView, SkiaGraphicsViewHandler> CommandMapper = new(ViewCommandMapper)
        {
            [nameof(ISkiaGraphicsView.Invalidate)] = MapInvalidate
        };

        public SkiaGraphicsViewHandler() : base(Mapper, CommandMapper)
        {
        }

        public SkiaGraphicsViewHandler(IPropertyMapper? mapper = null, CommandMapper? commandMapper = null)
            : base(mapper ?? Mapper, commandMapper ?? CommandMapper)
        {
        }

        protected override void ConnectHandler(PlatformView platformView)
        {
#if PLATFORM
            //platformView.Connect(VirtualView);
#endif
            base.ConnectHandler(platformView);
        }

        protected override void DisconnectHandler(PlatformView platformView)
        {
#if PLATFORM
            //platformView.Disconnect();
#endif
            base.DisconnectHandler(platformView);
        }
    }
}