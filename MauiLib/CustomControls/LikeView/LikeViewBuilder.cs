namespace MauiLib.CustomControls.LikeView
{
    using Drawable = SkiaSharp.SKBitmap;

    /// <summary>
    /// @date: 2018/11/7
    /// @author: LiRJ
    /// </summary>
    public class LikeViewBuilder
    {

        private int defaultColor;
        private int checkedColor;
        private float lrGroupCRatio;
        private float lrGroupBRatio;
        private float bGroupACRatio;
        private float tGroupBRatio;
        private int innerShapeScale;
        private int dotSizeScale;
        private Drawable defaultIcon;
        private Drawable checkedIcon;
        private int[] dotColors;
        private int ringColor;
        private float radius;
        private int cycleTime;
        private int unSelectCycleTime;
        private bool allowRandomDotColor;

        public LikeViewBuilder()
        {
            this.defaultColor = LikeView.DEFAULT_COLOR;
            this.checkedColor = LikeView.CHECKED_COLOR;
            this.lrGroupCRatio = HeartShapePathController.LR_GROUP_C_RATIO;
            this.lrGroupBRatio = HeartShapePathController.LR_GROUP_B_RATIO;
            this.bGroupACRatio = HeartShapePathController.B_GROUP_AC_RATIO;
            this.tGroupBRatio = HeartShapePathController.T_GROUP_B_RATIO;
            this.radius = 30;
            this.cycleTime = LikeView.DEFAULT_CYCLE_TIME;
            this.unSelectCycleTime = LikeView.DEFAULT_UN_SELECT_CYCLE_TIME;
            this.dotColors = LikeView.DEFAULT_DOT_COLORS;
            this.ringColor = LikeView.DEFAULT_RING_COLOR;
            this.innerShapeScale = LikeView.RADIUS_INNER_SHAPE_SCALE;
            this.dotSizeScale = LikeView.DOT_SIZE_SCALE;
            this.allowRandomDotColor = true;
        }
        /// <summary>
        /// <seealso cref=" LikeView#setDefaultColor(int)"/>
        /// </summary>
        public virtual LikeViewBuilder setDefaultColor(int defaultColor)
        {
            this.defaultColor = defaultColor;
            return this;

        }
        /// <summary>
        /// <seealso cref=" LikeView#setCheckedColor(int)"/>
        /// </summary>
        public virtual LikeViewBuilder setCheckedColor(int checkedColor)
        {
            this.checkedColor = checkedColor;
            return this;

        }
        /// <summary>
        /// <seealso cref=" LikeView#setLrGroupCRatio(float)"/>
        /// </summary>
        public virtual LikeViewBuilder setLrGroupCRatio(float lrGroupCRatio)
        {
            this.lrGroupCRatio = lrGroupCRatio;
            return this;
        }
        /// <summary>
        /// <seealso cref=" LikeView#setLrGroupBRatio(float)"/>
        /// </summary>
        public virtual LikeViewBuilder setLrGroupBRatio(float lrGroupBRatio)
        {
            this.lrGroupBRatio = lrGroupBRatio;
            return this;
        }
        /// <summary>
        /// <seealso cref=" LikeView#setBGroupACRatio(float)"/>
        /// </summary>
        public virtual LikeViewBuilder setBGroupACRatio(float bGroupACRatio)
        {
            this.bGroupACRatio = bGroupACRatio;
            return this;
        }
        /// <summary>
        /// <seealso cref=" LikeView#setTGroupBRatio(float)"/>
        /// </summary>
        public virtual LikeViewBuilder setTGroupBRatio(float tGroupBRatio)
        {
            this.tGroupBRatio = tGroupBRatio;
            return this;
        }
        /// <summary>
        /// <seealso cref=" LikeView#setDefaultColor(int)"/>
        /// </summary>
        public virtual LikeViewBuilder setDefaultIcon(Drawable defaultIcon)
        {
            this.defaultIcon = defaultIcon;
            return this;

        }
        /// <summary>
        /// <seealso cref=" LikeView#setCheckedIcon(Drawable)"/>
        /// </summary>
        public virtual LikeViewBuilder setCheckedIcon(Drawable checkedIcon)
        {
            this.checkedIcon = checkedIcon;
            return this;

        }
        /// <summary>
        /// <seealso cref=" LikeView#setRadius(float)"/>
        /// </summary>
        public virtual LikeViewBuilder setRadius(float radius)
        {
            this.radius = radius;
            return this;
        }
        /// <summary>
        /// <seealso cref=" LikeView#setCycleTime(int)"/>
        /// </summary>
        public virtual LikeViewBuilder setCycleTime(int cycleTime)
        {
            this.cycleTime = cycleTime;
            return this;
        }
        /// <summary>
        /// <seealso cref=" LikeView#setUnSelectCycleTime(int)"/>
        /// </summary>
        public virtual LikeViewBuilder setUnSelectCycleTime(int unSelectCycleTime)
        {
            this.unSelectCycleTime = unSelectCycleTime;
            return this;
        }

        /// <summary>
        /// <seealso cref=" LikeView#setInnerShapeScale(int)"/>
        /// </summary>
        public virtual LikeViewBuilder setInnerShapeScale(int innerShapeScale)
        {
            this.innerShapeScale = innerShapeScale;
            return this;

        }
        /// <summary>
        /// <seealso cref=" LikeView#setDotSizeScale(int)"/>
        /// </summary>
        public virtual LikeViewBuilder setDotSizeScale(int dotSizeScale)
        {
            this.dotSizeScale = dotSizeScale;
            return this;
        }
        /// <summary>
        /// <seealso cref=" LikeView#setDotColors(int[])"/>
        /// </summary>
        public virtual LikeViewBuilder setDotColors(int[] dotColors)
        {
            this.dotColors = dotColors;
            return this;
        }
        /// <summary>
        /// <seealso cref=" LikeView#setRingColor(int)"/>
        /// </summary>
        public virtual LikeViewBuilder setRingColor(int ringColor)
        {
            this.ringColor = ringColor;
            return this;
        }
        /// <summary>
        /// <seealso cref=" LikeView#setAllowRandomDotColor(boolean)"/>
        /// </summary>
        public virtual LikeViewBuilder setAllowRandomDotColor(bool allowRandomDotColor)
        {
            this.allowRandomDotColor = allowRandomDotColor;
            return this;
        }

        public virtual LikeView create()
        {
            LikeView likeView = new LikeView(radius, defaultColor, checkedColor);

            likeView.LrGroupCRatio = lrGroupCRatio;
            likeView.LrGroupBRatio = lrGroupBRatio;
            likeView.BGroupACRatio = bGroupACRatio;
            likeView.TGroupBRatio = tGroupBRatio;
            likeView.DefaultIcon = defaultIcon;
            likeView.CheckedIcon = checkedIcon;

            likeView.CycleTime = cycleTime;
            likeView.UnSelectCycleTime = unSelectCycleTime;
            likeView.DotColors = dotColors;
            likeView.RingColor = ringColor;
            likeView.InnerShapeScale = innerShapeScale;
            likeView.DotSizeScale = dotSizeScale;
            likeView.AllowRandomDotColor = allowRandomDotColor;
            return likeView;
        }

    }

}