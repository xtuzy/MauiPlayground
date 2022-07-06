using BlogFrameRate;
using MauiLib.GraphicExtension;

namespace MauiPlayground.Pages;

public partial class ShowBallsPage : ContentPage
{
    static bool isUseOffScreenBitmap = false;

    private FrameRateCalculator frameRateCalculator;
    private string FPSText;

    public ShowBallsPage()
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

    private void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e)
    {
        (graphicsView.Drawable as Drawable).FPSText = FPSText;
        graphicsView.Invalidate();
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if (isUseOffScreenBitmap)
            (graphicsView.Drawable as Drawable).offScreenContext = new OffScreenContext((int)width, (int)height);
        (graphicsView.Drawable as Drawable).ResizeInBlazor(width, height);
    }


    class Drawable : IDrawable
    {
        public OffScreenContext offScreenContext;

        public string FPSText = default;

        private BlazorCanvasTest2.Models.Field BallField = new BlazorCanvasTest2.Models.Field();

        public void ResizeInBlazor(double width, double height) => BallField.Resize(width, height);

        void Render(ICanvas canvas)
        {
            if (BallField.Balls.Count == 0)
                BallField.AddRandomBalls(3000);
            BallField.StepForward();

            foreach (var ball in BallField.Balls)
            {
                canvas.FillColor = ball.Color;
                //canvas.DrawArc((float)(ball.X - ball.R), (float)(ball.Y - ball.R), (float)(2 * ball.R), (float)(2 * ball.R), 0, (float)(2 * Math.PI), false,true);
                //canvas.FillArc((float)(ball.X - ball.R), (float)(ball.Y - ball.R), (float)(2 * ball.R), (float)(2 * ball.R), 0, (float)(2 * Math.PI), false);
                canvas.FillCircle((float)ball.X , (float)ball.Y , (float)ball.R);
            }
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (ShowBallsPage.isUseOffScreenBitmap)
            {
                //Skiasharp添加了一层Bitmap,我这里也尝试加一层
                var offScreenCanvas = PlatformCanvasExtension.FromOffScreenContext(offScreenContext);
                offScreenCanvas.FillColor = Colors.Black;
                offScreenCanvas.FillRectangle(0, 0, offScreenContext.Width, offScreenContext.Height);
                Render(offScreenCanvas);
                PlatformCanvasExtension.SaveToOffScreenContext(offScreenCanvas, offScreenContext);
                PlatformCanvasExtension.Draw(canvas, offScreenContext);
            }
            else
            {
                Render(canvas);
            }
            
            canvas.FontColor = Colors.White;
            canvas.DrawString(FPSText, 20, 20, HorizontalAlignment.Left);
        }
    }
}