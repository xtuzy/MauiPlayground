namespace MauiPlayground.Pages;
/// <summary>
/// https://github.com/lucyonegit/ball
/// </summary>
public partial class ShowFireworkPage : ContentPage
{
	public ShowFireworkPage()
	{
		InitializeComponent();

		graphicsView.Drawable = new FireworkDrawable();
		Task.Run(async () =>
		{
			while (true)
			{
				graphicsView.Dispatcher.Dispatch(() =>
				{
					graphicsView.Invalidate();
					(graphicsView.Drawable as FireworkDrawable).Update();

				});
				await Task.Delay(20);
			}
		});
	}

	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);
		var drawable = (graphicsView.Drawable as FireworkDrawable);
		drawable.windowinnerWidth = width;
		drawable.windowinnerHeight = height;
		drawable.onload();
	}
}

public class FireworkDrawable : IDrawable
{
	public double windowinnerWidth;
	public double windowinnerHeight;

	class Ball
	{
		public double x;
		public double y;
		public double r;
		public double v;
		public double vx;
		public double vy;
		public double g;
		public Color color;
	}

	class Star
	{
		public double x;
		public double y;
		public double r;
		public Color color;
	}

	List<Ball> ball = new List<Ball>();
	List<Ball> po = new List<Ball>();
	List<Star> star = new List<Star>();
	List<Ball> yhball = new List<Ball>();

	Random random = new Random();
	double GetRandom()
	{
		return random.Next(1, 100) / 100.0;
	}

	void setstar()
	{
		for (var r = 0; r < 500; r++)
		{
			var red = Math.Floor(GetRandom() * 55) + 200;
			var g = Math.Floor(GetRandom() * 55) + 200;
			var b = Math.Floor(GetRandom() * 55) + 200;
			var s = new Star()
			{
				x = GetRandom() * windowinnerWidth,
				y = GetRandom() * windowinnerHeight,
				r = GetRandom() * 5 * r / 6000,
				color = Color.FromRgb((int)red, (int)g, (int)b),
			};
			star.Add(s);
		}
	}

	void setball((double clientX, double clientY) e)
	{
		var v = Math.Floor(GetRandom() * 10) + 10;
		for (var r = 0; r < 1500; r++)
		{
			var vx = Math.Round(GetRandom() * 10) % 2 == 0 ? GetRandom() * -12 : GetRandom() * 12;
			var vy = Math.Sqrt(Math.Pow(v, 2) - Math.Pow(vx, 2)) - GetRandom() * 10;
			var red = GetRandom() * 256;
			var g = GetRandom() * 256;
			var b = GetRandom() * 256;
			var s = new Ball()
			{
				x = e.clientX,
				y = e.clientY,
				r = GetRandom() * 30 * r / 1500,
				v = 20,
				vx = vx,
				vy = Math.Round(GetRandom() * 10) % 2 == 0 ? vy : -vy,
				g = GetRandom() * 0.2,
				color = Color.FromRgb((int)red, (int)g, (int)b),
			};
			ball.Add(s);
		}
	}

	void setyhball((double clientX, double clientY) e, Color color)
	{
		var v = Math.Floor(GetRandom() * 10) + 10;
		for (var r = 0; r < 100; r++)
		{
			var vx = Math.Round(GetRandom() * 10) % 2 == 0 ? GetRandom() * -5 : GetRandom() * 5;
			var vy = Math.Sqrt(Math.Pow(v, 2) - Math.Pow(vx, 2)) - GetRandom() * 10;
			var red = Math.Floor(GetRandom() * 55) + 200;
			var g = Math.Floor(GetRandom() * 55) + 200;
			var b = Math.Floor(GetRandom() * 55) + 200;
			var s = new Ball()
			{
				x = e.clientX,
				y = e.clientY,
				r = GetRandom() * 1 * r / 500,
				v = 20,
				vx = vx,
				vy = vy,
				g = GetRandom() * 0.1,
				color = color,
				//color: `rgb(${r},${g},${b})`
			};
			yhball.Add(s);
		}
	}

	void setyh((double clientX, double clientY) e)
	{
		var s = Math.Floor(GetRandom() * 10);
		var red = GetRandom() * 256;
		var g = GetRandom() * 256;
		var b = GetRandom() * 256;
		var d = new Ball()
		{
			x = GetRandom() * windowinnerWidth,
			y = windowinnerHeight - 30,
			r = GetRandom() * 5,
			vx = 0,
			vy = -8,
			g = 0.05,
			color = Color.FromRgb((int)red, (int)g, (int)b),
		};
		po.Add(d);
	}

	(double clientX, double clientY) eve;
	Size cabout;

	public Action<(double clientX, double clientY)> MouseEvent;
	public void onload()
	{
		cabout.Width = windowinnerWidth;
		cabout.Height = windowinnerHeight;
		MouseEvent = (e) =>
		{
			eve = e;
		};

		setstar();
		Task.Run(async () =>
		{
			while (true)
			{
				setyh(eve);
				await Task.Delay(3000);
			}
		});
	}

	void show(ICanvas ctx)
	{
		render(ctx);
	}

	public void Update()
	{
		update(eve, cabout);
	}

	void render(ICanvas ctx)
	{
		// var lineGradient = ctx.createLinearGradient(0, 0, window.innerWidth, window.innerHeight);
		// lineGradient.addColorStop(0, 'rgba(20,18,16,0.2)');
		// lineGradient.addColorStop(0.5, 'rgba(30,32,34,0.2)');
		// lineGradient.addColorStop(1, 'rgba(14,0,2,0.2)');

		int width = (int)windowinnerWidth;
		int height = (int)windowinnerHeight;
		ctx.FillColor = Color.FromRgba(0, 0, 0, 0.2);
		ctx.FillRectangle(0, 0, width, height);

		renderYh(ctx);
		renderStar(ctx);
		//‰÷»æ±¨’®¡£◊”∂Øª≠
		for (var i = 0; i < ball.Count; i++)
		{
			/*if (ball.Count > 500)
			{
				ball.RemoveAt(i);
			}*/
			//ctx.BeginPath();
			ctx.FillColor = ball[i].color;
			//ctx.arc(ball[i].x, ball[i].y, ball[i].r, 0, 2 * Math.PI);
			ctx.FillArc((float)(ball[i].x - ball[i].r), (float)(ball[i].y - ball[i].r), (float)(2 * ball[i].r), (float)(2 * ball[i].r), 0, (float)(2 * Math.PI), true);
			//ctx.fill();
		}
	}

	void renderYh(ICanvas ctx)
	{
		//‰÷»æ—Ãª®…œ…˝
		for (var c = 0; c < po.Count; c++)
		{
			//ctx.beginPath();
			ctx.FillColor = po[c].color;
			//ctx.arc(po[c].x, po[c].y, po[c].r, 0, 2 * Math.PI);
			ctx.FillArc((float)(po[c].x - po[c].r), (float)(po[c].y - po[c].r), (float)(2 * po[c].r), (float)(2 * po[c].r), 0, (float)(2 * Math.PI), true);
			//ctx.fill();
			setyhball((clientX: po[c].x, clientY: po[c].y), po[c].color); //‰÷»æ—Ãª®÷‹Œßµƒª®ª
		}
		renderYhball(ctx);
	}

	void renderYhball(ICanvas ctx)
	{
		for (var c = 0; c < yhball.Count; c++)
		{

			//ctx.beginPath();
			ctx.FillColor = yhball[c].color;
			//ctx.arc(yhball[c].x, yhball[c].y, yhball[c].r, 0, 2 * Math.PI);
			ctx.FillArc((float)(yhball[c].x - yhball[c].r), (float)(yhball[c].y - yhball[c].r), (float)(2 * yhball[c].r), (float)(2 * yhball[c].r), 0, (float)(2 * Math.PI), true);

			//ctx.fill();
			if (yhball.Count > 50)
			{
				yhball.RemoveAt(c);
			}
		}
	}

	void renderStar(ICanvas ctx)
	{
		//‰÷»æ–«–«
		for (var g = 0; g < star.Count; g++)
		{
			var path = new PathF();

			//ctx.beginPath();
			ctx.FillColor = star[g].color;
			//ctx.arc(star[g].x, star[g].y, star[g].r, 0, 2 * Math.PI);
			ctx.FillArc((float)(star[g].x - star[g].r), (float)(star[g].y - star[g].r), (float)(2 * star[g].r), (float)(2 * star[g].r), 0, (float)(2 * Math.PI), true);
			//ctx.fill();
		}
	}

	//‰÷»æ±¨’®¡£◊”
	void update((double clientX, double clientY) eve, Size cabout)
	{
		for (var s = 0; s < ball.Count; s++)
		{
			ball[s].x += ball[s].vx;
			ball[s].y += ball[s].vy;
			ball[s].vy += ball[s].g;
			//œ¬±ﬂ‘µºÏ≤‚
			if (ball[s].y >= cabout.Height - ball[s].r)
			{
				ball[s].y = cabout.Height - ball[s].r;
				ball[s].vy = -Math.Abs(ball[s].vy) + 20;
				if (Math.Abs(ball[s].vy) <= 1)
				{
					ball[s].vy = 0;
				}
			}
			// //…œ±ﬂ‘µºÏ≤‚
			// if (ball[s].y <= ball[s].r) {
			//     ball[s].y = ball[s].r;
			//     ball[s].vy = -Math.abs(ball[s].vy) + 20;
			//     if (Math.abs(ball[s].vy) <= 1) {
			//         ball[s].vy = 0;
			//     }
			// }
			// //◊Û±ﬂ‘µºÏ≤‚
			// if (ball[s].x <= ball[s].r) {
			//     if (ball.length > 1000) {
			//         ball.splice(s, 1);
			//     }
			//     ball[s].x = ball[s].r;
			//     ball[s].vx = - ball[s].vx;
			// }
			// //”“±ﬂ‘µºÏ≤‚
			// if (ball[s].x >= cabout.width - ball[s].r) {
			//     if (ball.length > 1000) {
			//         ball.splice(s, 1);
			//     }
			//     ball[s].x = cabout.width - ball[s].r;
			//     ball[s].vx = - ball[s].vx;
			// }
			// if (eve) {
			//     var x = eve.clientX, y = eve.clientY;
			//     if (Math.pow((x - ball[s].x), 2) + Math.pow((y - ball[s].y), 2) <= Math.pow((ball[s].r + 10), 2)) {
			//         ball[s].x = ball[s].x;
			//         ball[s].y = ball[s].y;
			//         ball[s].vx = -ball[s].vx - 10;
			//         ball[s].vy = -ball[s].vy - 10;
			//     }
			// }
		}
		updatepo();
		updatehuball();
		updatestar(eve);
	}

	//‰÷»æ—Ãª®
	void updatepo()
	{
		for (var s = 0; s < po.Count; s++)
		{
			if (po[s].x < windowinnerWidth / 2)
			{
				//po[s].x += po[s].vx + GetRandom() * 5;
				po[s].x += po[s].vx + 1;
			}
			else
			{
				//po[s].x += po[s].vx - GetRandom() * 5;
				po[s].x += po[s].vx - 1;
			}
			po[s].y += po[s].vy;
			po[s].vy += po[s].g;
			if (Math.Abs(po[s].vy) <= 1)
			{
				var x = po[s].x;
				var y = po[s].y;
				po.RemoveAt(s);
				setball((clientX: x, clientY: y));
			}
		}
	}

	//‰÷»æ—Ãª®µƒªª®
	void updatehuball()
	{
		for (var s = 0; s < yhball.Count; s++)
		{
			yhball[s].x += yhball[s].vx;
			yhball[s].y += yhball[s].vy;
			yhball[s].vy += yhball[s].g;
		}
	}

	//‰÷»æ–«–«
	void updatestar((double clientX, double clientY) eve)
	{
		(double x, double y) center = (windowinnerWidth / 2, windowinnerHeight / 2);
		for (var s = 0; s < star.Count; s++)
		{
			if (eve != default)
			{
				star[s].x += -(eve.clientX - center.x) / (windowinnerWidth - 300);
				star[s].y += -(eve.clientY - center.y) / (windowinnerHeight - 300);
			}
			else
			{
				star[s].x += Math.Floor(GetRandom() * 10) % 2 == 0 ? GetRandom() * 0.5 : -GetRandom() * 0.5;
				star[s].y += Math.Floor(GetRandom() * 10) % 2 == 0 ? GetRandom() * 0.5 : -GetRandom() * 0.5;
			}
		}
	}

	public void Draw(ICanvas canvas, RectF dirtyRect)
	{
		show(canvas);
	}
}