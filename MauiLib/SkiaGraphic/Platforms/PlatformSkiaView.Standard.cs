#if NET && !WINDOWS && !__IOS__ && !__ANDROID__
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLib.SkiaGraphic.Platforms
{
    public class PlatformSkiaView
    {
        public IDrawable Drawable;
        public PlatformSkiaView(IDrawable drawable = null)
        {
            Drawable = drawable;
        }
    }
}
#endif