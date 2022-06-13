using SkiaSharp;

namespace MauiLib.CustomControls.LikeView
{
    /*using Path = android.graphics.Path;
    using PointF = android.graphics.PointF;*/

    /// <summary>
    /// @date: 2018/11/6
    /// @author: LiRJ
    /// </summary>
    public sealed class HeartShapePathController
    {
        /// <summary>
        /// Bézier曲线画圆的近似常数
        /// </summary>
        private const float BEZIER_C = 0.551915024494f;
        public const float LR_GROUP_C_RATIO = 0.92f;
        public const float LR_GROUP_B_RATIO = 1.0f;
        public const float B_GROUP_AC_RATIO = 0.7f;
        public const float T_GROUP_B_RATIO = 0.5f;
        private readonly float mLrGroupCRatio;
        private readonly float mLrGroupBRatio;
        private readonly float mBGroupACRatio;
        private readonly float mTroupBRatio;

        private PointF tPointA;
        private PointF tPointB;
        private PointF tPointC;
        private PointF rPointA;
        private PointF rPointB;
        private PointF rPointC;
        private PointF bPointA;
        private PointF bPointB;
        private PointF bPointC;
        private PointF lPointA;
        private PointF lPointB;
        private PointF lPointC;

        public HeartShapePathController(float lrGroupCRatio, float lrGroupBRatio, float bGroupLRRatio, float tGroupBRatio)
        {
            this.mLrGroupCRatio = lrGroupCRatio;
            this.mLrGroupBRatio = lrGroupBRatio;
            this.mBGroupACRatio = bGroupLRRatio;
            this.mTroupBRatio = tGroupBRatio;
        }
        /// <summary>
        /// 初始化Bézier 曲线四组控制点
        /// </summary>
        private void updateControlPoints(int radius)
        {
            float offset = BEZIER_C * radius;

            tPointA = new PointF(-offset, -radius);
            tPointB = new PointF(0, -radius * mTroupBRatio);
            tPointC = new PointF(offset, -radius);

            rPointA = new PointF(radius, -offset);
            rPointB = new PointF(radius * mLrGroupBRatio, 0);
            rPointC = new PointF(radius * mLrGroupCRatio, offset);

            bPointA = new PointF(-offset, radius * mBGroupACRatio);
            bPointB = new PointF(0, radius);
            bPointC = new PointF(offset, radius * mBGroupACRatio);

            lPointA = new PointF(-radius, -offset);
            lPointB = new PointF(-radius * mLrGroupBRatio, 0);
            lPointC = new PointF(-radius * mLrGroupCRatio, offset);
        }

        public SKPath getPath(int radius)
        {
            updateControlPoints(radius);
            SKPath path = new SKPath();
            path.MoveTo(tPointB.X, tPointB.Y);
            path.CubicTo(tPointC.X, tPointC.Y, rPointA.X, rPointA.Y, rPointB.X, rPointB.Y);
            path.CubicTo(rPointC.X, rPointC.Y, bPointC.X, bPointC.Y, bPointB.X, bPointB.Y);
            path.CubicTo(bPointA.X, bPointA.Y, lPointC.X, lPointC.Y, lPointB.X, lPointB.Y);
            path.CubicTo(lPointA.X, lPointA.Y, tPointA.X, tPointA.Y, tPointB.X, tPointB.Y);
            return path;
        }

    }

}