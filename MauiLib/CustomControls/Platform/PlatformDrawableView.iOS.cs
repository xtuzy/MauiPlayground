#if __IOS__ || __MACCATALYST__
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace MauiLib.CustomControls.Platform
{

    public class PlatformDrawableView : UIView
    {
        public event EventHandler<PlatformDrawEventArgs> PlatformDraw;

        public override void Draw(CoreGraphics.CGRect rect)
        {
            base.Draw(rect);
            PlatformDraw?.Invoke(this, new PlatformDrawEventArgs(rect));
        }

        public event EventHandler<EventArgs> PlatformMeasure;
        public override void LayoutSubviews()
        {
            PlatformMeasure?.Invoke(this, new EventArgs());
            base.LayoutSubviews();
        }

    }
}
#endif