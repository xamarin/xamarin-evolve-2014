using System;
using Xamarin.Forms;

namespace MobileData
{

	public class BoolToColorConverter : ExpressionToColorConverter<bool>
	{
		public BoolToColorConverter()
			: base(c => c)
		{
		}
	}

}
