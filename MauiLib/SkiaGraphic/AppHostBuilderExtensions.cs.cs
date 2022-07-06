using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLib.SkiaGraphic
{
    public static class AppHostBuilderExtensions
    {
        public static MauiAppBuilder UseSkiaGraphicsView(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler(typeof(SkiaGraphicsView), typeof(SkiaGraphicsViewHandler));
            });

            return builder;
        }
    }
}
