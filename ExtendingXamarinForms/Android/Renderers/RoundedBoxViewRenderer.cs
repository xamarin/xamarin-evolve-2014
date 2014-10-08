using System;
using Xamarin.Forms;
using ExtendingXamarinForms;
using ExtendingXamarinForms.Android;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;

[assembly: ExportRendererAttribute(typeof(RoundedBoxView), 
	typeof(RoundedBoxViewRenderer))]

namespace ExtendingXamarinForms.Android
{
	public class RoundedBoxViewRenderer : BoxRenderer
    {
		public RoundedBoxViewRenderer()
		{
			this.SetWillNotDraw(false);
		}

		public override void Draw(Canvas canvas)
		{
			RoundedBoxView rbv = (RoundedBoxView)this.Element;

			Rect rc = new Rect();
			GetDrawingRect(rc);

			Rect interior = rc;
			interior.Inset((int)rbv.StrokeThickness, (int)rbv.StrokeThickness);

			// The shadow is fairly pointless on Android as the bounds are clipped. You can add support
			// if you need to, but it is best to not do something like that on the Native interface

			#region Drawing the Shadow

//			if (rbv.HasShadow) {
//				Paint shadowPaint = new Paint () {
//					Color = Xamarin.Forms.Color.FromRgba(0.0, 0.0, 0.0, 0.5).ToAndroid (),
//					AntiAlias = true
//				};
//
//				var shadowOffset = 5.0;
//
//				var shadowRect = new Rect (rc);
//				shadowRect.Offset ((int)shadowOffset, (int)shadowOffset);
//
//				canvas.DrawRoundRect(
//					new RectF(shadowRect), (float)rbv.CornerRadius, (float)rbv.CornerRadius, shadowPaint);
//			}

			#endregion

			Paint p = new Paint() {
				Color = rbv.Color.ToAndroid(),
				AntiAlias = true,
			};

			canvas.DrawRoundRect(new RectF(interior), (float)rbv.CornerRadius, (float)rbv.CornerRadius, p);

			p.Color = rbv.Stroke.ToAndroid();
			p.StrokeWidth = (float)rbv.StrokeThickness;
			p.SetStyle(Paint.Style.Stroke);

			canvas.DrawRoundRect(new RectF(rc), (float)rbv.CornerRadius, (float)rbv.CornerRadius, p);
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == RoundedBoxView.CornerRadiusProperty.PropertyName ||
			    e.PropertyName == RoundedBoxView.StrokeProperty.PropertyName ||
			    e.PropertyName == RoundedBoxView.StrokeThicknessProperty.PropertyName ||
			    e.PropertyName == BoxView.ColorProperty.PropertyName ||
			    e.PropertyName == RoundedBoxView.HasShadowProperty.PropertyName) {
					Invalidate ();
			}
		}
    }
}

