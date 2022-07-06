#if WINDOWS
using Microsoft.Maui.Graphics.Skia.Views;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLib.SkiaGraphic.Platforms
{
    public class PlatformSkiaView : Microsoft.Maui.Graphics.Skia.Views.SkiaGraphicsView
    {
        public PlatformSkiaView(IDrawable drawable = null):base(drawable)
        {
            
        }
    }
}
#endif