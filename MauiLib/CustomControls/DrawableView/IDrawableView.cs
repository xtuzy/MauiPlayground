using MauiLib.CustomControls.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLib.CustomControls.DrawableView
{
    public interface IDrawableView : IView
    {
        event EventHandler<PlatformDrawEventArgs> PaintSurface;
        event EventHandler Loaded;
        event EventHandler Unloaded;

        event EventHandler TouchDown;
        event EventHandler TouchMove;
        event EventHandler TouchUp;

        void Invalidate();

        void Load();
        void Unload();

        void OnTouchDown(Point point);
        void OnTouchMove(Point point);
        void OnTouchUp(Point point);

        void OnDraw(object? sender, PlatformDrawEventArgs e);
    }
}
