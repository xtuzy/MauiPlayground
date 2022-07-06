using BlogFrameRate;
using Boids.Model;
using Boids.Viewer;
using MauiLib.GraphicExtension;

namespace MauiPlayground.Pages;
//https://github.com/swharden/Csharp-Data-Visualization/tree/main/dev/old/drawing/boids
public partial class ShowBoidsPage : ContentPage
{
	Field field;
	public ShowBoidsPage()
	{
		InitializeComponent();
		graphicsView.Drawable = new Drawable();

		System.Timers.Timer timer1 = new System.Timers.Timer(50);
		timer1.Elapsed += timer1_Tick;
		timer1.Start();

		frameRateCalculator = new BlogFrameRate.FrameRateCalculator();
		frameRateCalculator.FrameRateUpdated = (info) =>
		{
			FPSText = info.Frames.ToString();
		};
		frameRateCalculator.Start();
	}

	string FPSText = default;
	private void Reset() => field = new Field(W, H, 500);

	private void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e)
	{
		if (field == null)
			return;
		field.Advance();
		(graphicsView.Drawable as Drawable).context?.Dispose();
		(graphicsView.Drawable as Drawable).context = SDRender.RenderField(field);
		(graphicsView.Drawable as Drawable).FPSText = FPSText;
		graphicsView.Invalidate();
	}

	int W;
	int H;
	private FrameRateCalculator frameRateCalculator;

	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);
		W = (int)Width;
		H = (int)Height;
		Reset();
	}

	class Drawable : IDrawable
	{
		public string FPSText = default;
		public OffScreenContext context;
		public void Draw(ICanvas canvas, RectF dirtyRect)
		{
			if (context != null)
				PlatformCanvasExtension.Draw(canvas, context);
			canvas.DrawString(FPSText, 20, 20, HorizontalAlignment.Left);
		}
	}
}