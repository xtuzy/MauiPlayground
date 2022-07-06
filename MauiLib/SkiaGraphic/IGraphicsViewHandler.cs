#if __IOS__ || MACCATALYST || MONOANDROID || WINDOWS || TIZEN || __ANDROID__
using MauiLib.SkiaGraphic.Platforms;
using PlatformView = MauiLib.SkiaGraphic.Platforms.PlatformSkiaView;
#else
using PlatformView = System.Object;
#endif

namespace MauiLib.SkiaGraphic
{
    public partial interface ISkiaGraphicsViewHandler : IViewHandler
    {
        new ISkiaGraphicsView VirtualView { get; }
        new PlatformView PlatformView { get; }
    }
}