using System;
using Xamarin.Forms;

namespace MobileData
{

	public class CurrencyToColorConverter : ExpressionToColorConverter<double>
	{
		public CurrencyToColorConverter()
			:base(c => c >= 0)
		{
		}
	}

}
