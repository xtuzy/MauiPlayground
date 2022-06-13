namespace MauiLib.CustomControls.LikeView
{
	/// <summary>
	/// @date: 2018/11/7
	/// @author: LiRJ
	/// </summary>
	public sealed class State
	{
		/// <summary>
		/// 1.绘制心形并伴随缩小和颜色渐变
		/// </summary>
		public const int HEART_VIEW = 0;
		/// <summary>
		/// 2.绘制圆并伴随放大和颜色渐变
		/// </summary>
		public const int CIRCLE_VIEW = 1;
		/// <summary>
		/// 3.绘制圆环并伴随放大和颜色渐变
		/// </summary>
		public const int RING_VIEW = 2;
		/// <summary>
		/// 4.圆环减消失、心形放大、周围环绕十四圆点
		/// </summary>
		public const int RING_DOT__HEART_VIEW = 3;
		/// <summary>
		/// 5.环绕的十四圆点向外移动并缩小、透明度渐变、渐隐
		/// </summary>
		public const int DOT__HEART_VIEW = 4;
	}

}