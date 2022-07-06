using BlogFrameRate;

namespace MauiPlayground.Pages;

public partial class ShowSkiaGraphicsViewPage : ContentPage
{
    private FrameRateCalculator frameRateCalculator;
    private string FPSText;

    public ShowSkiaGraphicsViewPage()
    {
        InitializeComponent();

        skiaGraphicsView.Drawable = new Drawable();
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

    private void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e)
    {
        (skiaGraphicsView.Drawable as Drawable).FPSText = FPSText;
        skiaGraphicsView.Invalidate();
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        (skiaGraphicsView.Drawable as Drawable).ResizeInBlazor(width, height);
    }


    class Drawable : IDrawable
    {
        public string FPSText = default;

        private BlazorCanvasTest2.Models.Field BallField = new BlazorCanvasTest2.Models.Field();

        public void ResizeInBlazor(double width, double height) => BallField.Resize(width, height);

        void Render(ICanvas canvas)
        {
            if (BallField.Balls.Count == 0)
                BallField.AddRandomBalls(1000);
            BallField.StepForward();

            canvas.StrokeColor = Colors.White;
            foreach (var ball in BallField.Balls)
            {
                canvas.FillColor = ball.Color;
                canvas.DrawArc((float)(ball.X - ball.R), (float)(ball.Y - ball.R), (float)(2 * ball.R), (float)(2 * ball.R), 0, (float)(2 * Math.PI), false, true);
            }
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            Render(canvas);
            canvas.FontColor = Colors.White;
            canvas.DrawString(FPSText, 20, 20, HorizontalAlignment.Left);
        }
    }
}