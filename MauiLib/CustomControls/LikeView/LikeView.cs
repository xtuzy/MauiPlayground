using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using System;

namespace MauiLib.CustomControls.LikeView
{
    /*using ObjectAnimator = android.animation.ObjectAnimator;
    using PropertyValuesHolder = android.animation.PropertyValuesHolder;
    using ValueAnimator = android.animation.ValueAnimator;
    using AnimatorUpdateListener = android.animation.ValueAnimator.AnimatorUpdateListener;
    using Context = android.content.Context;
    using TypedArray = android.content.res.TypedArray;
    using Canvas = android.graphics.Canvas;

    using Nullable = android.support.annotation.Nullable;
    using AttributeSet = android.util.AttributeSet;
    using Log = android.util.Log;
    using TypedValue = android.util.TypedValue;
    using View = android.view.View;
    using LinearInterpolator = android.view.animation.LinearInterpolator;
    using OvershootInterpolator = android.view.animation.OvershootInterpolator;
    using Checkable = android.widget.Checkable;*/

    using Canvas = SkiaSharp.SKCanvas;
    using Paint = SkiaSharp.SKPaint;
    using RectF = SkiaSharp.SKRect;
    using Drawable = SkiaSharp.SKBitmap;
    using ValueAnimator = Animation;
    using ObjectAnimator = Animation;
    /// <summary>
    /// Created
    /// by jaren on 2017/5/26.
    /// </summary>

    public partial class LikeView : SKCanvasView //: Checkable
    {

        /// <summary>
        /// 圆最大半径（心形）
        /// </summary>
        private float mRadius;
        /// <summary>
        /// View选中用时
        /// </summary>
        private int mCycleTime;

        /// <summary>
        /// View取消选中用时
        /// </summary>
        private int mUnSelectCycleTime;
        private int mDefaultColor;
        private int mCheckedColor;
        private float mLrGroupCRatio;
        private float mLrGroupBRatio;
        private float mBGroupACRatio;
        private float mTGroupBRatio;
        private int mInnerShapeScale;
        private int mDotSizeScale;
        private Drawable mDefaultIcon;
        private Drawable mCheckedIcon;
        private int[] mDotColors;
        private int mRingColor;
        private bool mAllowRandomDotColor;

        /// <summary>
        /// 是否已点赞
        /// </summary>
        private bool isChecked;
        /// <summary>
        /// 心形默认选中颜色
        /// </summary>
        public const int CHECKED_COLOR = unchecked((int)0xffe53a42);
        /// <summary>
        /// 心形默认未选中颜色
        /// </summary>
        public const int DEFAULT_COLOR = unchecked((int)0Xff657487);
        /// <summary>
        /// 圆环默认颜色
        /// </summary>
        public const int DEFAULT_RING_COLOR = unchecked((int)0Xffde7bcc);

        public const int DEFAULT_CYCLE_TIME = 2000;

        public const int DEFAULT_UN_SELECT_CYCLE_TIME = 200;

        /// <summary>
        /// 环绕圆点的颜色
        /// </summary>
        public static readonly int[] DEFAULT_DOT_COLORS = new int[] { unchecked((int)0xffdaa9fa), unchecked((int)0xfff2bf4b), unchecked((int)0xffe3bca6), unchecked((int)0xff329aed), unchecked((int)0xffb1eb99), unchecked((int)0xff67c9ad), unchecked((int)0xffde6bac) };
        /// <summary>
        /// 距离外环间隔  mRadius*1/RADIUS_INNER_SHAPE_SCALE
        /// </summary>
        public const int RADIUS_INNER_SHAPE_SCALE = 6;
        public const int DOT_SIZE_SCALE = 7;

        private const float RING_WIDTH_RATIO = 2f;
        private const float SIZE_RATIO = 5.2f;

        private float mCenterX;
        private float mCenterY;
        private Paint mPaint;
        private ValueAnimator animatorTime;
        private ValueAnimator animatorArgb;
        //private ValueAnimator.AnimatorUpdateListener lvAnimatorUpdateListener;
        /// <summary>
        /// 外部圆环半径
        /// </summary>
        private int mCurrentRadius;
        private int mCurrentColor;
        private int mCurrentState;
        private double mCurrentPercent;
        private float rDotL;
        private float rDotS;
        private float offS;
        private float offL;
        private bool isMax;
        private float dotR;
        private ObjectAnimator unselectAnimator;
        private HeartShapePathController mHeartShapePathController;

        public LikeView(float radius, int defaultColor, int checkededColor)
        {
            /*TypedArray array = context.Theme.obtainStyledAttributes(attrs, R.styleable.LikeView, defStyleAttr, 0);
            mRadius = array.getDimension(R.styleable.LikeView_cirRadius, dp2px(10));
            mCycleTime = array.getInt(R.styleable.LikeView_cycleTime, DEFAULT_CYCLE_TIME);
            mUnSelectCycleTime = array.getInt(R.styleable.LikeView_unSelectCycleTime, DEFAULT_UN_SELECT_CYCLE_TIME);
            mDefaultColor = array.getColor(R.styleable.LikeView_defaultColor, DEFAULT_COLOR);
            mCheckedColor = array.getColor(R.styleable.LikeView_checkedColor, CHECKED_COLOR);
            mRingColor = array.getColor(R.styleable.LikeView_ringColor, DEFAULT_RING_COLOR);
            mLrGroupCRatio = array.getFloat(R.styleable.LikeView_lrGroupCRatio, HeartShapePathController.LR_GROUP_C_RATIO);
            mLrGroupBRatio = array.getFloat(R.styleable.LikeView_lrGroupBRatio, HeartShapePathController.LR_GROUP_B_RATIO);
            mBGroupACRatio = array.getFloat(R.styleable.LikeView_bGroupACRatio, HeartShapePathController.B_GROUP_AC_RATIO);
            mTGroupBRatio = array.getFloat(R.styleable.LikeView_tGroupBRatio, HeartShapePathController.T_GROUP_B_RATIO);
            mInnerShapeScale = array.getInteger(R.styleable.LikeView_innerShapeScale, RADIUS_INNER_SHAPE_SCALE);
            mDotSizeScale = array.getInteger(R.styleable.LikeView_dotSizeScale, DOT_SIZE_SCALE);
            mAllowRandomDotColor = array.getBoolean(R.styleable.LikeView_allowRandomDotColor, true);

            if (array.hasValue(R.styleable.LikeView_defaultLikeIconRes))
            {
                mDefaultIcon = array.getDrawable(R.styleable.LikeView_defaultLikeIconRes);
            }
            if (array.hasValue(R.styleable.LikeView_checkedLikeIconRes))
            {
                mCheckedIcon = array.getDrawable(R.styleable.LikeView_checkedLikeIconRes);
            }

            array.recycle(); */

            Radius = radius;

            mPaint = new Paint();
            mCurrentRadius = (int)mRadius;
            mCurrentColor = defaultColor;
            CheckedColor = checkededColor;
            dotR = mRadius / mDotSizeScale;
            mDotColors = DEFAULT_DOT_COLORS;

            this.SizeChanged += onSizeChanged;
            this.Unloaded += onDetachedFromWindow;

            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                // Handle the tap
                toggle();
            };
            this.GestureRecognizers.Add(tapGestureRecognizer);
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);
            Canvas canvas = e.Surface.Canvas;
            canvas.Clear(SKColors.Azure);

            canvas.Translate(mCenterX, mCenterY); //使坐标原点在canvas中心位置
            switch (mCurrentState)
            {
                case State.HEART_VIEW:
                    drawInnerShape(canvas, mCurrentRadius, isChecked);
                    break;
                case State.CIRCLE_VIEW:
                    drawCircle(canvas, mCurrentRadius, mCurrentColor);
                    break;
                case State.RING_VIEW:
                    drawRing(canvas, mCurrentRadius, mCurrentColor, (float)mCurrentPercent);
                    break;
                case State.RING_DOT__HEART_VIEW:
                    drawDotWithRing(canvas, mCurrentRadius, mCurrentColor);
                    break;
                case State.DOT__HEART_VIEW:
                    drawDot(canvas, mCurrentRadius, mCurrentColor);
                    break;
            }
        }

        //绘制内部图形
        private void drawInnerShape(Canvas canvas, int radius, bool isChecked)
        {
            if (HasIcon)
            {
                Drawable icon = isChecked ? mCheckedIcon : mDefaultIcon;
                //icon.setBounds(-radius, -radius, radius, radius);
                //icon.draw(canvas);
                canvas.DrawBitmap(icon, 0, 0);
            }
            else
            {
                int color = isChecked ? mCheckedColor : mCurrentColor;
                mPaint.Color = Color.FromInt(color).ToSKColor();
                //mPaint.Color = SKColors.Red;
                mPaint.IsAntialias = true;
                mPaint.IsDither = true;
                mPaint.Style = SKPaintStyle.Fill;
                mHeartShapePathController = new HeartShapePathController(mLrGroupCRatio, mLrGroupBRatio, mBGroupACRatio, mTGroupBRatio);
                canvas.DrawPath(mHeartShapePathController.getPath(radius), mPaint);
            }
        }

        private bool HasIcon
        {
            get
            {
                return mCheckedIcon != null && mDefaultIcon != null;
            }
        }

        //绘制圆
        private void drawCircle(Canvas canvas, int radius, int color)
        {
            mPaint.Color = new SKColor((uint)color);
            mPaint.IsAntialias = true;
            mPaint.Style = SKPaintStyle.Fill;
            canvas.DrawCircle(0f, 0f, radius, mPaint);
        }

        //绘制圆环
        private void drawRing(Canvas canvas, int radius, int color, float percent)
        {

            mPaint.Color = new SKColor((uint)mRingColor);
            mPaint.IsAntialias = true;
            mPaint.Style = SKPaintStyle.Stroke;
            mPaint.StrokeWidth = RING_WIDTH_RATIO * mRadius * percent;
            RectF rectF = new RectF(-radius, -radius, radius, radius);
            canvas.DrawArc(rectF, 0, 360, false, mPaint);
        }

        //绘制圆点、圆环、心形
        private void drawDotWithRing(Canvas canvas, int radius, int color)
        {
            dotR = mRadius / mDotSizeScale;
            mPaint.Color = new SKColor((uint)mRingColor);
            mPaint.IsAntialias = true;
            //用于计算圆环宽度，最小0，与动画进度负相关
            double ringPercent = (1f - mCurrentPercent > 1f ? 1f : 1f - mCurrentPercent) * 0.2f;
            //环形宽度缩小
            double ringWidth = RING_WIDTH_RATIO * mRadius * ringPercent;
            mPaint.StrokeWidth = (float)ringWidth;
            mPaint.Style = SKPaintStyle.Stroke;
            if (mCurrentPercent <= 1)
            {
                RectF rectF = new RectF(-radius, -radius, radius, radius);
                canvas.DrawArc(rectF, 0, 360, false, mPaint);
            }

            //圆点圆心位置
            float innerR = (float)(radius - ringWidth / 2 + dotR);
            double angleA = 0;
            double angleB = -Math.PI / 20;
            if (rDotL <= SIZE_RATIO * mRadius / 2)
            { //限制圆点的扩散范围
                offS += dotR / 17;
                offL += dotR / 14;
                rDotS = radius - mRadius / 12 / 2 + offS;
                rDotL = innerR + offL;
            }

            mPaint.Style = SKPaintStyle.Fill;
            for (int i = 0; i < 7; i++)
            {
                canvas.DrawCircle((float)(rDotS * Math.Sin(angleA)), (float)(rDotS * Math.Cos(angleA)), dotR, mPaint);
                angleA += 2 * Math.PI / 7;
                canvas.DrawCircle((float)(rDotL * Math.Sin(angleB)), (float)(rDotL * Math.Cos(angleB)), dotR, mPaint);
                angleB += 2 * Math.PI / 7;
            }
            mCurrentRadius = (int)(mRadius / mInnerShapeScale + (mInnerShapeScale * 2 - 2) * mRadius * mCurrentPercent / mInnerShapeScale);
            drawInnerShape(canvas, mCurrentRadius, true);

        }

        //绘制圆点、心形
        private void drawDot(Canvas canvas, int radius, int color)
        {
            mPaint.IsAntialias = true;
            mPaint.Style = SKPaintStyle.Fill;

            double angleA = 0;
            double angleB = -Math.PI / 20;
            float dotRS;
            float dotRL;
            if (rDotL <= SIZE_RATIO * mRadius / 2)
            { //限制圆点的扩散范围
                rDotS += dotR / 17;
                rDotL += dotR / 14;
            }
            if (!isMax && mCurrentRadius <= 1.1 * mRadius)
            {
                offL += dotR / 14;
                mCurrentRadius = (int)(mRadius / 3 + offL * 4);

            }
            else
            {
                isMax = true;
            }

            if (isMax && mCurrentRadius > mRadius)
            {
                mCurrentRadius = (int)(mCurrentRadius - dotR / 16);
            }
            drawInnerShape(canvas, mCurrentRadius, true);

            //圆点逐渐变小
            dotRS = ((float)(dotR * (1 - mCurrentPercent)));
            dotRL = (float)((dotR * (1 - mCurrentPercent)) * 3 > dotR ? dotR : (dotR * (1 - mCurrentPercent)) * 2);
            for (int i = 0; i < mDotColors.Length; i++)
            {
                mPaint.Color = Color.FromInt(mDotColors[i]).ToSKColor();
                //            //圆点逐渐透明
                //            mPaint.setAlpha((int) (255 * (1 - mCurrentPercent)));
                canvas.DrawCircle((float)(rDotS * Math.Sin(angleA)), (float)(rDotS * Math.Cos(angleA)), dotRS, mPaint);
                angleA += 2 * Math.PI / 7;
                canvas.DrawCircle((float)(rDotL * Math.Sin(angleB)), (float)(rDotL * Math.Cos(angleB)), dotRL, mPaint);
                angleB += 2 * Math.PI / 7;
            }
        }

        private readonly Random mDotColorsRandom = new Random();
        private void randomDotColors()
        {
            int length = mDotColors.Length;
            for (int i = 0; i < length; i++)
            {
                int random = mDotColorsRandom.Next(length);
                int currentColor = mDotColors[i];
                mDotColors[i] = mDotColors[random];
                mDotColors[random] = currentColor;
            }
        }

        protected internal void onSizeChanged(object sender, EventArgs e)
        //protected internal override void onSizeChanged(int w, int h, int oldw, int oldh)
        {
            //base.onSizeChanged(w, h, oldw, oldh);
            mCenterX = (float)this.DesiredSize.Width / 2;
            mCenterY = (float)this.DesiredSize.Height / 2;
        }

        /*protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            int mWidth, mHeight;
            mWidth = (int)(SIZE_RATIO * mRadius + 2 * dotR);
            mHeight = (int)(SIZE_RATIO * mRadius + 2 * dotR);
            setMeasuredDimension(mWidth, mHeight);
        }*/

        /// <summary>
        /// 展现View选中后的变化效果
        /// </summary>
        private void startSelectViewMotion()
        {
            resetState();
            if (mAllowRandomDotColor)
            {
                randomDotColors();
            }
            /*if (animatorTime == null)
            {
                animatorTime = ValueAnimator.ofInt(0, 1200);
                animatorTime.Duration = mCycleTime;
                animatorTime.Interpolator = new LinearInterpolator(); //需要随时间匀速变化
            }
            if (lvAnimatorUpdateListener == null)
            {
                lvAnimatorUpdateListener = new LvAnimatorUpdateListener(this);
                animatorTime.addUpdateListener(lvAnimatorUpdateListener);
            }*/
            if (animatorTime == null)
            {
                animatorTime = new ValueAnimator((animatedValue) =>
                {
                    var outerInstance = this;
                    if (animatedValue == 0)
                    {
                        if (outerInstance.animatorArgb == null || !outerInstance.animatorArgb.IsPaused)
                        {
                            outerInstance.animatorArgb = ofArgb(outerInstance.mDefaultColor, unchecked((int)0Xfff74769), outerInstance.mCheckedColor);
                            /*outerInstance.animatorArgb.Duration = outerInstance.mCycleTime * 28 / 120;
                            outerInstance.animatorArgb.Interpolator = new LinearInterpolator();
                            outerInstance.animatorArgb.start();*/
                            outerInstance.animatorArgb.Commit(this, nameof(animatorArgb), 16, (uint)(mCycleTime * 28 / 120), Easing.Linear);
                        }
                    }
                    else if (animatedValue <= 100)
                    {
                        double percent = outerInstance.calcPercent(0f, 100f, animatedValue);
                        outerInstance.mCurrentRadius = (int)(outerInstance.mRadius - outerInstance.mRadius * percent);
                        if (outerInstance.animatorArgb != null && !outerInstance.animatorArgb.IsPaused)
                        {
                            //outerInstance.mCurrentColor = (int)outerInstance.animatorArgb.AnimatedValue;
                            outerInstance.mCurrentColor = (int)outerInstance.animatorArgb.Progress;
                        }
                        outerInstance.mCurrentState = State.HEART_VIEW;
                        invalidate();
                    }
                    else if (animatedValue <= 280)
                    {
                        double percent = outerInstance.calcPercent(100f, 340f, animatedValue); //此阶段未达到最大半径
                        outerInstance.mCurrentRadius = (int)(2 * outerInstance.mRadius * percent);
                        if (outerInstance.animatorArgb != null && !outerInstance.animatorArgb.IsPaused)
                        {
                            //outerInstance.mCurrentColor = (int)outerInstance.animatorArgb.AnimatedValue;
                            outerInstance.mCurrentColor = (int)outerInstance.animatorArgb.Progress;
                        }
                        outerInstance.mCurrentState = State.CIRCLE_VIEW;
                        invalidate();
                    }
                    else if (animatedValue <= 340)
                    {
                        double percent = outerInstance.calcPercent(100f, 340f, animatedValue); //半径接上一阶段增加，此阶段外环半径已经最大值
                        outerInstance.mCurrentPercent = 1f - percent + 0.2f > 1f ? 1f : 1f - percent + 0.2f; //用于计算圆环宽度，最小0.2，与动画进度负相关
                        outerInstance.mCurrentRadius = (int)(2 * outerInstance.mRadius * percent);
                        if (outerInstance.animatorArgb != null && !outerInstance.animatorArgb.IsPaused)
                        {
                            //outerInstance.mCurrentColor = (int)outerInstance.animatorArgb.AnimatedValue;
                            outerInstance.mCurrentColor = (int)outerInstance.animatorArgb.Progress;
                        }
                        outerInstance.mCurrentState = State.RING_VIEW;
                        invalidate();
                    }
                    else if (animatedValue <= 480)
                    {
                        double percent = outerInstance.calcPercent(340f, 480f, animatedValue); //内环半径增大直至消亡
                        outerInstance.mCurrentPercent = percent;
                        outerInstance.mCurrentRadius = (int)(2 * outerInstance.mRadius); //外环半径不再改变
                        outerInstance.mCurrentState = State.RING_DOT__HEART_VIEW;
                        invalidate();
                    }
                    else if (animatedValue <= 1200)
                    {
                        double percent = outerInstance.calcPercent(480f, 1200f, animatedValue);
                        outerInstance.mCurrentPercent = percent;
                        outerInstance.mCurrentState = State.DOT__HEART_VIEW;
                        invalidate();
                        if (animatedValue == 1200)
                        {
                            //outerInstance.animatorTime.cancel();
                            outerInstance.animatorTime.Pause();
                            if (!outerInstance.isChecked)
                            {
                                outerInstance.restoreDefaultView();
                            }
                            else
                            {
                                outerInstance.restoreDefaultViewChecked();
                            }
                        }
                    }
                }, 0, 1200, Easing.Linear);
            }
            //animatorTime.start();
            animatorTime.Commit(this, nameof(animatorTime), 16, (uint)mCycleTime, Easing.Linear);
        }

        private void startUnselectViewMotion()
        {
            if (unselectAnimator == null)
            {
                /*PropertyValuesHolder holderX = PropertyValuesHolder.ofFloat("scaleX", 1.0f, 0.8f, 1.0f);
                PropertyValuesHolder holderY = PropertyValuesHolder.ofFloat("scaleY", 1.0f, 0.8f, 1.0f);
                unselectAnimator = ObjectAnimator.ofPropertyValuesHolder(this, holderX, holderY).setDuration(mUnSelectCycleTime);
                unselectAnimator.Interpolator = new OvershootInterpolator();*/
                unselectAnimator = new ValueAnimator()
                {
                    {0,0.8, new ValueAnimator((v) => this.Scale = v, 1, 0.8, Easing.Default) },
                    {0.8,1, new ValueAnimator((v) => this.Scale = v, 0.8, 1, Easing.Default) },
                };
            }
            //unselectAnimator.start();
            unselectAnimator.Commit(this, nameof(unselectAnimator), 16, (uint)mUnSelectCycleTime);
        }

        /// <summary>
        /// 重置为初始状态
        /// </summary>
        private void resetState()
        {
            mCurrentPercent = 0;
            mCurrentRadius = 0;
            isMax = false;
            rDotS = 0;
            rDotL = 0;
            offS = 0;
            offL = 0;
        }

        private double calcPercent(double start, double end, double current)
        {
            return (current - start) / (end - start);
        }

        /// <returns> 由于颜色变化的动画API是SDK21 添加的，这里导入了源码的 ArgbEvaluator </returns>
        private ValueAnimator ofArgb(params int[] values)
        {
            /*ValueAnimator anim = new ValueAnimator();
            anim.IntValues = values;
            anim.Evaluator = ArgbEvaluator.Instance;
            return anim;*/
            var anim = new Animation();
            for (int index = 0; index < values.Length; index++)
            {
                anim.Add(((double)index) / values.Length, ((double)index + 1) / values.Length, ColorAnimationExtensions.BackgroundColorAnimation(this, Color.FromInt(values[index])));
            }
            return anim;
        }

        private float dp2px(int value)
        {
            //return TypedValue.applyDimension(TypedValue.COMPLEX_UNIT_DIP, value, Resources.DisplayMetrics);
            return (float)Microsoft.Maui.Devices.DeviceDisplay.Current.MainDisplayInfo.Density * value;

        }

        /// <summary>
        /// 选择/取消选择 有动画
        /// </summary>
        private void selectLike(bool isSetChecked)
        {
            isChecked = isSetChecked;
            if (isSetChecked)
            {
                cancelAnimator();
                startSelectViewMotion();
            }
            else
            {
                if (!AnimatorTimeRunning)
                {
                    restoreDefaultView();
                    startUnselectViewMotion();
                }
            }

        }

        /// <summary>
        /// 选择/取消选择 无动画
        /// </summary>
        private void selectLikeWithoutAnimator(bool isSetChecked)
        {
            isChecked = isSetChecked;
            cancelAnimator();
            if (isSetChecked)
            {
                restoreDefaultViewChecked();
            }
            else
            {
                restoreDefaultView();
            }

        }

        private void restoreDefaultViewChecked()
        {
            mCurrentColor = mCheckedColor;
            mCurrentRadius = (int)mRadius;
            mCurrentState = State.HEART_VIEW;
            invalidate();
        }

        private void restoreDefaultView()
        {
            mCurrentColor = mDefaultColor;
            mCurrentRadius = (int)mRadius;
            mCurrentState = State.HEART_VIEW;
            invalidate();
        }

        private void invalidate()
        {
            this.InvalidateSurface();
        }

        private void cancelAnimator()
        {
            if (AnimatorTimeRunning)
            {
                //animatorTime.cancel();
                animatorTime.Pause();
            }
        }

        private bool AnimatorTimeRunning
        {
            get
            {
                return animatorTime != null && !animatorTime.IsPaused;
            }
        }

        protected internal void onDetachedFromWindow(object sender, EventArgs e)
        {
            //        Log.i("onDetachedFromWindow","onDetachedFromWindow");
            //base.onDetachedFromWindow();
            releaseAnimator(nameof(animatorTime));
            releaseAnimator(nameof(animatorArgb));
            releaseAnimator(nameof(unselectAnimator));
            //lvAnimatorUpdateListener = null;
        }

        private void releaseAnimator(string animationName)
        {
            /*if (animator != null)
            {
                animator.end();
                animator.removeAllListeners();
                animator.removeAllUpdateListeners();
            }*/
            this.AbortAnimation(animationName);
        }

        /*=========================================public=========================================*/

        public bool Checked
        {
            set
            {
                selectLike(value);
            }
            get
            {
                return this.isChecked;
            }
        }

        /// <summary>
        /// the method is equivalent to <seealso cref="#setChecked(boolean)"/><br>
        /// but it performs no animator and it will cancel the  animator that is running.
        /// </summary>
        public virtual bool CheckedWithoutAnimator
        {
            set
            {
                selectLikeWithoutAnimator(value);
            }
        }

        public void toggle()
        {
            selectLike(!isChecked);
        }

        /// <summary>
        /// the method is equivalent to <seealso cref=" #toggle()"/><br>
        /// but it performs no animator and it will cancel the  animator that is running.
        /// </summary>
        public virtual void toggleWithoutAnimator()
        {
            selectLikeWithoutAnimator(!isChecked);
        }

        /// <summary>
        /// Sets the default color for the heart shape.
        /// if using icon instead of  heart shape, sets the default-icon main color is recommend.
        /// </summary>
        public virtual int DefaultColor
        {
            set
            {
                this.mDefaultColor = value;
            }
        }
        /// <summary>
        /// Sets the checked color for the heart shape.<br>
        /// if using icon instead of  heart shape, sets the checked-icon main color is recommend.
        /// </summary>
        public virtual int CheckedColor
        {
            set
            {
                this.mCheckedColor = value;
            }
        }

        /// <summary>
        /// Sets unselect animation-duration(ms)
        /// </summary>
        public virtual int UnSelectCycleTime
        {
            set
            {
                this.mUnSelectCycleTime = value;
            }
        }
        /// <summary>
        /// Sets controller point ratio to change left and right of the bottom part of heart shape view. </summary>
        /// <param name="lrGroupCRatio"> between 0 and 1.0 inclusive </param>
        public virtual float LrGroupCRatio
        {
            set
            {
                this.mLrGroupCRatio = value;
            }
        }
        /// <summary>
        /// Sets controller point ratio to change left and right of the center of heart shape view. </summary>
        /// <param name="lrGroupBRatio"> between 0 and 1.0 inclusive </param>
        public virtual float LrGroupBRatio
        {
            set
            {
                this.mLrGroupBRatio = value;
            }
        }
        /// <summary>
        /// Sets controller point ratio to change the bottom of heart shape view. </summary>
        /// <param name="bGroupACRatio"> between 0 and 1.0 inclusive </param>
        public virtual float BGroupACRatio
        {
            set
            {
                this.mBGroupACRatio = value;
            }
        }
        /// <summary>
        /// Sets controller point ratio to change the top of heart shape view. </summary>
        /// <param name="tGroupBRatio"> between 0 and 1.0 inclusive </param>
        public virtual float TGroupBRatio
        {
            set
            {
                this.mTGroupBRatio = value;
            }
        }
        /// <summary>
        /// Sets the default icon,using icon instead of heart shape.
        /// </summary>
        public virtual Drawable DefaultIcon
        {
            set
            {
                this.mDefaultIcon = value;
            }
        }

        /// <summary>
        /// Sets the checked icon,using icon instead of heart shape.
        /// </summary>
        public virtual Drawable CheckedIcon
        {
            set
            {
                this.mCheckedIcon = value;
            }
        }
        /// <summary>
        /// Sets the radius size which can determine the LikeView size
        /// </summary>
        public virtual float Radius
        {
            set
            {
                this.mRadius = value;
                //设置半径时canvas绘制心形中心位置也变了
                mCenterX = mRadius;
                mCenterY = mRadius;
            }
        }
        /// <summary>
        /// Sets select animation-duration(ms)
        /// </summary>
        public virtual int CycleTime
        {
            set
            {
                this.mCycleTime = value;
            }
        }

        /// <summary>
        ///  Sets the inner shape size , there is  positive correlation between  inner shape size and innerShapeScale
        /// </summary>
        /// <param name="innerShapeScale">  value range in [2,10] is suggested ,default  <seealso cref="#RADIUS_INNER_SHAPE_SCALE"/> </param>
        public virtual int InnerShapeScale
        {
            set
            {
                this.mInnerShapeScale = value;
            }
        }

        /// <summary>
        /// Sets the dot size , there is  negative correlation between dot size and dotSizeScale
        /// </summary>
        /// <param name="dotSizeScale"> value range in [7,14] is suggested  ,default <seealso cref="#DOT_SIZE_SCALE"/> </param>
        public virtual int DotSizeScale
        {
            set
            {
                this.mDotSizeScale = value;
            }
        }

        /// <summary>
        /// Sets the dots color .
        /// </summary>
        public virtual int[] DotColors
        {
            set
            {
                if (value.Length != DEFAULT_DOT_COLORS.Length)
                {
                    throw new System.ArgumentException("length of dotColors should be " + DEFAULT_DOT_COLORS.Length);
                }
                this.mDotColors = value;
            }
        }
        /// <summary>
        /// Sets the ring color.
        /// </summary>
        public virtual int RingColor
        {
            set
            {
                this.mRingColor = value;
            }
        }
        /// <summary>
        /// Sets whether random dot color is allowed,default is true.
        /// </summary>
        public virtual bool AllowRandomDotColor
        {
            set
            {
                this.mAllowRandomDotColor = value;
            }
        }
    }

}