﻿    using Android.Widget;
    using Android.Content.Res;
    using Android.Graphics.Drawables;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    using System.ComponentModel;
    using Android.Graphics;
    using CustomSliderDemo;
    using CustomSliderDemo.Droid;

    [assembly: ExportRenderer(typeof(CustomSlider), typeof(MySliderRenderer))]
    namespace CustomSliderDemo.Droid
    {
        public class MySliderRenderer : SliderRenderer
        {
            private CustomSlider view;
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Slider> e)
            {
                base.OnElementChanged(e);
                if (e.OldElement != null || e.NewElement == null)
                    return;
                view = (CustomSlider)Element;
                if (!string.IsNullOrEmpty(view.ThumbImage))
               {    // Set Thumb Icon
                    Control.SetThumb(Resources.GetDrawable(view.ThumbImage));
                }
                else if (view.ThumbColor != Xamarin.Forms.Color.Default ||
                    view.MaxColor != Xamarin.Forms.Color.Default ||
                    view.MinColor != Xamarin.Forms.Color.Default)
                    Control.Thumb.SetColorFilter(view.ThumbColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                    Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(view.MinColor.ToAndroid());
                    Control.ProgressTintMode = PorterDuff.Mode.SrcIn;
                    //this is for Maximum Slider line Color
                    Control.ProgressBackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(view.MaxColor.ToAndroid());
                    Control.ProgressBackgroundTintMode = PorterDuff.Mode.SrcIn;
            }
            protected override void OnLayout(bool changed, int l, int t, int r, int b)
            {
                base.OnLayout(changed, l, t, r, b);
                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.JellyBean)
                {
                    if (Control == null)
                    { return;}
                    SeekBar ctrl = Control;
                    Drawable thumb = ctrl.Thumb;
                    int thumbTop = ctrl.Height / 2 - thumb.IntrinsicHeight / 2;
                    thumb.SetBounds(thumb.Bounds.Left, thumbTop,
                                    thumb.Bounds.Left + thumb.IntrinsicWidth, thumbTop + thumb.IntrinsicHeight);
                }
            }
        }
    }