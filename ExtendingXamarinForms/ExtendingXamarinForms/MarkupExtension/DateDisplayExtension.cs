using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace ExtendingXamarinForms
{
	[ContentProperty("DisplayType")] // { DateDisplay <DisplayType> }
	public class DateDisplayExtension : IMarkupExtension
	{
		public string DisplayType {
			get;
			set;
		}

		public string Binding {
			get;
			set;
		}

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (serviceProvider == null)
				throw new ArgumentNullException ("A ServiceProvider must be supplied");

			// Lets try and calculate the value of the column
			if (DisplayType == "Date")
				return DateTime.Now.ToString ("D");
			else if (DisplayType == "Time")
				return DateTime.Now.ToString ("t");
			else
				return "The value could not be determined";
		}
	}
}

