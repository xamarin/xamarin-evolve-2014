using System;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using MonoTouch.CoreLocation;
using Xamarin.Forms;
using ExtendingXamarinForms;
using ExtendingXamarinForms.iOS;
using System.Drawing;

//[assembly: ExportRendererAttribute (typeof(RoundedBoxView), typeof(RoundedBoxViewRenderer))]
[assembly: ExportRendererAttribute (typeof(RoundedBoxView), typeof(RoundedBoxViewRendererV1))]

namespace ExtendingXamarinForms.iOS
{
	public class RoundedBoxViewRenderer : ViewRenderer<RoundedBoxView, UIView>
	{
		UIView childView;

		protected override void OnElementChanged (ElementChangedEventArgs<RoundedBoxView> e)
		{
			base.OnElementChanged (e);

			var rbv = e.NewElement;
			if (rbv != null) {
				var shadowView = new UIView ();

				childView = new UIView () {
					BackgroundColor = rbv.Color.ToUIColor (),
					Layer = {
						CornerRadius = (float)rbv.CornerRadius,
						BorderColor = rbv.Stroke.ToCGColor (),
						BorderWidth = (float)rbv.StrokeThickness,
						MasksToBounds = true
					},
					AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
				};

				shadowView.Add (childView);

				if (rbv.HasShadow) {
					shadowView.Layer.ShadowColor = UIColor.Black.CGColor;
					shadowView.Layer.ShadowOffset = new SizeF (3, 3);
					shadowView.Layer.ShadowOpacity = 1;
					shadowView.Layer.ShadowRadius = 5;
				}

				SetNativeControl (shadowView);
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == RoundedBoxView.CornerRadiusProperty.PropertyName)
				childView.Layer.CornerRadius = (float)this.Element.CornerRadius;
			else if (e.PropertyName == RoundedBoxView.StrokeProperty.PropertyName)
				childView.Layer.BorderColor = this.Element.Stroke.ToCGColor ();
			else if (e.PropertyName == RoundedBoxView.StrokeThicknessProperty.PropertyName)
				childView.Layer.BorderWidth = (float)this.Element.StrokeThickness;
			else if (e.PropertyName == BoxView.ColorProperty.PropertyName)
				childView.BackgroundColor = this.Element.Color.ToUIColor ();
			else if (e.PropertyName == RoundedBoxView.HasShadowProperty.PropertyName) {
				if (Element.HasShadow) {
					NativeView.Layer.ShadowColor = UIColor.Black.CGColor;
					NativeView.Layer.ShadowOffset = new SizeF (3, 3);
					NativeView.Layer.ShadowOpacity = 1;
					NativeView.Layer.ShadowRadius = 5;
				} else {
					NativeView.Layer.ShadowColor = UIColor.Clear.CGColor;
					NativeView.Layer.ShadowOffset = new SizeF ();
					NativeView.Layer.ShadowOpacity = 0;
					NativeView.Layer.ShadowRadius = 0;
				}
			}
		}
	}

	/// <summary>
	/// A mechanism using draw. You can use tools like PaintCode in order to generate the code
	/// </summary>
	public class RoundedBoxViewRendererV1 : BoxRenderer
	{
		public override void Draw (System.Drawing.RectangleF rect)
		{
			RoundedBoxView rbv = (RoundedBoxView)this.Element;

			using (var context = UIGraphics.GetCurrentContext ()) {

				context.SetFillColor (rbv.Color.ToCGColor ());
				context.SetStrokeColor (rbv.Stroke.ToCGColor ());
				context.SetLineWidth ((float)rbv.StrokeThickness);

				var rc = this.Bounds.Inset ((int)rbv.StrokeThickness, (int)rbv.StrokeThickness);

				float radius = (float)rbv.CornerRadius;
				radius = Math.Max (0, Math.Min (radius, Math.Max (rc.Height / 2, rc.Width / 2)));

				var path = CGPath.FromRoundedRect (rc, radius, radius);
				context.AddPath (path);
				context.DrawPath (CGPathDrawingMode.FillStroke);
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == RoundedBoxView.CornerRadiusProperty.PropertyName
			    || e.PropertyName == RoundedBoxView.StrokeProperty.PropertyName
			    || e.PropertyName == RoundedBoxView.StrokeThicknessProperty.PropertyName)
				this.SetNeedsDisplay ();
		}
	}
}

