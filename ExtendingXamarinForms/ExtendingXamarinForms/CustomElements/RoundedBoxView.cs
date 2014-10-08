using System;
using Xamarin.Forms;

namespace ExtendingXamarinForms
{
	public class RoundedBoxView : BoxView
    {
		public static readonly BindableProperty CornerRadiusProperty =
			BindableProperty.Create<RoundedBoxView, double>(p => p.CornerRadius, defaultValue: 0);

		public double CornerRadius
		{
			get { return (double)base.GetValue(CornerRadiusProperty);}
			set { base.SetValue(CornerRadiusProperty, value);}
		}

		public static readonly BindableProperty StrokeProperty = 
			BindableProperty.Create<RoundedBoxView,Color>(
				p => p.Stroke, Color.Transparent);

		public Color Stroke {
			get { return (Color)GetValue(StrokeProperty); }
			set { SetValue(StrokeProperty, value); }
		}

		public static readonly BindableProperty StrokeThicknessProperty = 
			BindableProperty.Create<RoundedBoxView,double>(
				p => p.StrokeThickness, default(double));

		public double StrokeThickness {
			get { return (double)GetValue(StrokeThicknessProperty); }
			set { SetValue(StrokeThicknessProperty, value); }
		}

		public static readonly BindableProperty HasShadowProperty = 
			BindableProperty.Create<RoundedBoxView,bool>(
				p => p.HasShadow, default(bool));

		public bool HasShadow {
			get { return (bool)GetValue(HasShadowProperty); }
			set { SetValue(HasShadowProperty, value); }
		}
    }
}

