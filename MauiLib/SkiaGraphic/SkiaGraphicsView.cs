using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLib.SkiaGraphic
{
    public class SkiaGraphicsView : View, ISkiaGraphicsView
    {
        public IDrawable Drawable { get; set; }

        public void Invalidate()
        {
            Handler?.Invoke(nameof(IGraphicsView.Invalidate));
        }
    }
}
