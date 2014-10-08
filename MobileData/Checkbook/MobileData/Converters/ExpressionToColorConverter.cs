using System;
using Xamarin.Forms;

namespace MobileData
{

	public class ExpressionToColorConverter<T> : IValueConverter
	{
		public Color TrueColor { get; set; }
		public Color FalseColor { get; set; }
		public Predicate<T> Expression { get; set; }

		public ExpressionToColorConverter(Predicate<T> expr)
		{
			Expression = expr;
		}

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return (Expression != null && Expression((T)value))
				? TrueColor : FalseColor;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
